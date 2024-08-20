using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Context
{
    public class EmircanContext : IdentityDbContext<BlogUser,BlogRole,Guid>
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

        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DbEmircanBlog;Trusted_Connection=True;");
        }
    }
}
