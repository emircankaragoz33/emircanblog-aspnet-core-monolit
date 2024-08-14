using EmircanBlog_Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Context
{
    public class EmircanContext : DbContext
    {

        public EmircanContext()
        {
            
        }
        public EmircanContext(DbContextOptions<EmircanContext> options) : base(options)
        {
                
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
