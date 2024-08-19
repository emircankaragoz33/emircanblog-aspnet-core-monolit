using EmircanBlog_Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c=>c.Category).WithMany(c=>c.Articles).HasForeignKey(c=>c.CategoryId).OnDelete(DeleteBehavior.Restrict);
<<<<<<< HEAD
            builder.HasOne(c=>c.User).WithMany(c=>c.Articles).HasForeignKey(c=>c.UserId).OnDelete(DeleteBehavior.Restrict);

=======
            builder.HasOne(c=>c.Image).WithMany(c=>c.Articles).HasForeignKey(c=>c.ImageId).OnDelete(DeleteBehavior.Restrict);
>>>>>>> servisler yazıldı mapper eklendi.
            
        }
    }
}
