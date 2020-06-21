using DockerTest3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTest3.Services
{
    public class HtmlWordsService : IHtmlWordService
    {
        public IEnumerable<HtmlWord> GetHtmlWords()
        {
            List < HtmlWord > words= new List<HtmlWord>();
            HtmlWord htmlWord = new HtmlWord
            {
                SaltedHash="ssss",
                Word = "first",
                count=4
            };
            words.Add(htmlWord);

            return words;
        }
    }
}
