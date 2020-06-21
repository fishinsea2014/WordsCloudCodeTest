using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTest3.Helper
{
    /// <summary>
    /// Handle an html
    /// e.g. find all words, caculate the frequency of the words.
    /// </summary>
    public class WebsiteWordsHelper
    {
        private List<string> _words;
        private HtmlDocument _html;
        private HtmlNode _rootNode;

        public WebsiteWordsHelper(HtmlDocument html)
        {

        }


    }
}
