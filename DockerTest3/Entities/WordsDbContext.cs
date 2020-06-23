using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace DockerTest3.Entities
{
    public class WordsDbContext: DbContext
    {
        public WordsDbContext(DbContextOptions<WordsDbContext> options): base(options) { }

        public virtual DbSet<HtmlWord> HtmlWord { get; set; }

    }
}
