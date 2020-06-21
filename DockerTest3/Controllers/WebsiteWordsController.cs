using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        [Route("CreateWordsList")]
        public string CreateWordsList([FromBody]string stringUrl)
        {
            string res = _htmlWordService.GetHtmlWords().ToString();
            return $"Get words from {stringUrl} and {res}";
        }
    }
}
