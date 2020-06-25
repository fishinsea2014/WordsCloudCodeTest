using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTest3.Models
{
    /// <summary>
    /// DTO is used to interact with front-end codes
    /// Do not business logic 
    /// Consistent with the relevant entity class, which is HtmlWord.
    /// </summary>
    public class HtmlWordDto
    {
        public string Text { get; set; }
        public int Weight { get; set; }
    }
}
