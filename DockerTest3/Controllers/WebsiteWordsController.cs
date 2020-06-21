using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DockerTest3.Models;
using DockerTest3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace DockerTest3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteWordsController : ControllerBase
    {
        private readonly ILogger<WebsiteWordsController> _logger;
        private readonly IHtmlWordService _htmlWordService;

        public WebsiteWordsController(ILogger<WebsiteWordsController> logger,
            IHtmlWordService htmlWordService)
        {
            _logger = logger;
            _htmlWordService = htmlWordService;
        }

        [HttpGet]
        [Route("CreateWordsList/{url}")]
        public async Task<string> CreateWordsListAsync([FromRoute]string url)
        {
            List<HtmlWordDto> wordList = await _htmlWordService.GetWordCloudData(url);

            string res = _htmlWordService.GetHtmlWords(url).ToString();
            string urlNew = System.Web.HttpUtility.UrlDecode(url);
            return $"Get words from {url}, {urlNew} and {res}";
        }
    }
}
