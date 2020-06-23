
using System;
using Xunit;
using DockerTest3.Services;
using DockerTest3.Models;
using System.Collections.Generic;
using Moq;
using DockerTest3.Entities;
using Microsoft.Extensions.Logging;
using Jason.Common.Helper;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace UnitTestProject
{
    public class HtmlWordsServiceTest
    {
        private readonly HtmlWordsService _htmlWordsService;
        private readonly WordsDbContext _wordsDbContext;
        private readonly DbContextOptions<WordsDbContext> _dbOptions;
        private readonly ILogger<HtmlWordsService> _logger;
        private readonly SaltHashHelper _saltHashHelper;
        public HtmlWordsServiceTest()
        {
            _dbOptions = new DbContextOptions<WordsDbContext>();
            _wordsDbContext = new WordsDbContext(_dbOptions);
            _logger = new Mock<ILogger<HtmlWordsService>>().Object;
            _saltHashHelper = new SaltHashHelper();
            _htmlWordsService = new HtmlWordsService(_wordsDbContext,_logger,_saltHashHelper);
        }
        [Fact]
        public async void GetWordCloudDataShould()
        {
            List< HtmlWordDto> res = (List<HtmlWordDto>) await _htmlWordsService.GetWordCloudData("http://www.google.com");
            Assert.NotEmpty(res);

        }
    }
}
