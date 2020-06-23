using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTest3.Entities
{
    public class HtmlWord
    {
        [Key]
        public string SaltedHash { get; set; }

        [Required]        
        public string Word { get; set; }

        [Required]
        public int count { get; set; }

        [Required]
        public string Salt { get; set; }
    }
}
