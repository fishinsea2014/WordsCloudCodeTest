using DockerTest3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTest3.Services
{
    public interface IHtmlWordService
    {
        IEnumerable<HtmlWord> GetHtmlWords();
    }
}
