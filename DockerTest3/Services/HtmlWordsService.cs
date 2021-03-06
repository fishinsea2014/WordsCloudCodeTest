﻿using DockerTest3.Entities;
using DockerTest3.Models;
using HtmlAgilityPack;
using Jason.Common.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DockerTest3.Services
{
    public class HtmlWordsService : IHtmlWordService
    {
        List<string> _words;
        private readonly WordsDbContext _wordsDbContext;
        private readonly ILogger<HtmlWordsService> _logger;
        private readonly SaltHashHelper _saltHashHelper;
        public HtmlWordsService(
            WordsDbContext wordsDbContext, 
            ILogger<HtmlWordsService> logger,
            SaltHashHelper saltHashHelper
            )
        {
            _words = new List<string>();
            _wordsDbContext = wordsDbContext;
            _logger = logger;
            _saltHashHelper = saltHashHelper;

        }
        public IEnumerable<HtmlWord> GetAllWords()
        {
            return _wordsDbContext.HtmlWord.OrderByDescending(i =>i.count);
        }
                
        /// <summary>
        /// Fetch words from a website page, count the frequencies,  
        /// and then put them into a list of word objects.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<IEnumerable<HtmlWordDto>> GetWordCloudData(string url)
        {
            List<HtmlWordDto> wordCloudData = new List<HtmlWordDto>();
            string htmlContent = await ParseHtml(url);
            if (htmlContent == String.Empty)
            {
                return null;
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);
            HtmlNode rootNode = htmlDocument.DocumentNode;
            GetWords(rootNode);
            IEnumerable<KeyValuePair<string, int>> wordsCount = CountWords();
            //Save words count data into database
            var x = _wordsDbContext.HtmlWord.OrderByDescending(i => i.count);

            foreach (var item in wordsCount)
            {
                wordCloudData.Add(
                    new HtmlWordDto()
                    {
                        Text = item.Key,
                        Weight = item.Value
                    });
                var wordInDb = x.Where(w => w.Word == item.Key).FirstOrDefault();
                if (wordInDb == null)
                {
                    var hashedWord = _saltHashHelper.GenerateSaltedHash(64,item.Key);
                    _wordsDbContext.Add(
                        new HtmlWord
                        {
                            SaltedHash = hashedWord.Hash,
                            Word = item.Key,
                            count = item.Value,
                            Salt = hashedWord.Salt
                        }
                   );
                }
                else
                {
                    wordInDb.count += item.Value;
                }
            };
            _wordsDbContext.SaveChanges();

            return wordCloudData;
        }

        /// <summary>
        /// Count the frequency of each word.
        /// Save the result in a dictionary.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<KeyValuePair<string, int>> CountWords()
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (string s in _words)
            {
                if (String.IsNullOrEmpty(s)) continue;
                if (IsNotWord(s)) continue;               

                if (wordsCount.ContainsKey(s))
                {
                    wordsCount[s] += 1;
                    continue;
                }
                wordsCount.Add(s, 1);
            }

            //Choose top 100 words
            var wordsDescending = from word in wordsCount orderby word.Value descending select word;
            var topHundredWords = wordsDescending.Take(100);

            return topHundredWords;
        }

        /// <summary>
        /// If a non-English character found, then not a English word and return true.
        /// Else it's a English word and return false. 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsNotWord(string str)
        {
            Regex regExp = new Regex ("[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]");
            return regExp.IsMatch(str);
        }

        /// <summary>
        /// Utilise recursion to find all the words in the Html file 
        /// </summary>
        /// <param name="node"></param>
        private void GetWords(HtmlNode node)
        {
            
            //If not root node and has "#" in node name, then neglect the node.
            if (node.Name.Contains("#") && node.Name != "#document") return;
            //If the node is a script, then negliect the node.
            if (node.Name.Contains("script")
                || node.Name.Contains("meta")
                || node.Name.Contains("title")
                || node.Name.Contains("head")
                || node.Name.Contains("style")) return;

            if (node.InnerText.Trim() != null)
            {                
                string innerText = node.InnerText.Trim();                
                _words.AddRange(GetWordsFromString(innerText));
            }
            Console.WriteLine(node.Name);
            HtmlNodeCollection childNodes = node.ChildNodes;
            if (childNodes != null)
            {
                foreach (HtmlNode item in childNodes)
                {
                    GetWords(item);
                }
            }
            return;
        }

        /// <summary>
        /// Extract words from a string, which is the content of a node here.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public IList<string> GetWordsFromString(string str)
        {
            IList<string> strList = new List<string>();
            //Utilise regex to extract word from a string, 
            //There are two regex condition
            //1. Matching camal case
            //2. Matching English characters.
            Regex reg = new Regex("(?:([A-Z][a-z]*)|([a-zA-Z]+))");

            MatchCollection matchList = reg.Matches(str);
            foreach (Match m in matchList)
            {
                Console.WriteLine(m.Value);
                strList.Add(m.Value);
            }
            return strList;
        }


        /// <summary>
        /// Fetch html content from a website page.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> ParseHtml(string url)
        {
            string responseBody = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Method", "Get");
                httpClient.DefaultRequestHeaders.Add("KeepAlive", "false");
                httpClient.DefaultRequestHeaders.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");
                try 
                {
                    HttpResponseMessage res = await httpClient.GetAsync(url);
                    res.EnsureSuccessStatusCode();
                    responseBody = await res.Content.ReadAsStringAsync();
                }
                catch(Exception err)
                {
                    _logger.LogError(err.Message);
                }

                
            };
            return responseBody;
        }
    }
}
