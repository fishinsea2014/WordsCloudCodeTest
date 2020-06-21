using DockerTest3.Entities;
using DockerTest3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTest3.Services
{
    public class HtmlWordsService : IHtmlWordService
    {
        public IEnumerable<HtmlWord> GetHtmlWords(string url)
        {

            List < HtmlWord > words= new List<HtmlWord>();
            string _url;
            public HtmlWordsService ()
            {

            }
            HtmlWord htmlWord = new HtmlWord
            {
                SaltedHash="ssss",
                Word = "first",
                count=4
            };
            words.Add(htmlWord);

            return words;
        }

        public async Task<IEnumerable<HtmlWordDto>> GetWordCloudData(string url)
            //public IEnumerable<HtmlWordDto> GetWordCloudData(string url)
        {

            return ("Ok");
        }


    }
}
