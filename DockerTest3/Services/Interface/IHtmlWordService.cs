using DockerTest3.Entities;
using DockerTest3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTest3.Services
{
    public interface IHtmlWordService
    {
        IEnumerable<HtmlWord> GetAllWords();
        Task<IEnumerable<HtmlWordDto>> GetWordCloudData(string url);

    }
}
