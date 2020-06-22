
using System;
using Xunit;
using DockerTest3.Services;
using DockerTest3.Models;
using System.Collections.Generic;

namespace UnitTestProject
{
    public class HtmlWordsServiceTest
    {
        private readonly HtmlWordsService _htmlWordsService;
        public HtmlWordsServiceTest()
        {
            _htmlWordsService = new HtmlWordsService();
        }
        [Fact]
        public async void GetWordCloudDataShould()
        {
            List< HtmlWordDto> res = (List<HtmlWordDto>) await _htmlWordsService.GetWordCloudData("http://www.google.com");
            Assert.NotEmpty(res);

        }
    }
}
