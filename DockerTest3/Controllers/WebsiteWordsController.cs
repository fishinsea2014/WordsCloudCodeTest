using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        [Route("CreateWordCloud/{urlStr}")]
        public async Task<ActionResult<IEnumerable<HtmlWordDto>>> CreateWordCloudAsync([FromRoute]string urlStr)
        {
            //List<HtmlWordDto> wordList = await _htmlWordService.GetWordCloudData(url);
            string url = System.Web.HttpUtility.UrlDecode(urlStr);
            var res = await _htmlWordService.GetWordCloudData(url);
            
            return Ok(res);
        }
    }
}
