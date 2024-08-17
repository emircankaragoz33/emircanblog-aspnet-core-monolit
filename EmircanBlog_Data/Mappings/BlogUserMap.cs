using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Mappings
{
    public class BlogUserMap : IEntityTypeConfiguration<BlogUser>
    {
        public void Configure(EntityTypeBuilder<BlogUser> builder)
        {
            builder.HasKey(c => c.Id);

            var admin = new BlogUser()
            {
                Id = Guid.Parse("{8F9DB5F5-B666-4773-97D6-E888A014606B}"),
                Email = "emircankaragoz@hotmail.com",
                FirstName = "Emircan",
                LastName = "Karagöz",
                UserName = "emircankaragoz",
                NormalizedEmail = "EMIRCANKARAGOZ@HOTMAIL.COM",
                NormalizedUserName = "EMIRCANKARAGOZ",
                ImageId = Guid.Parse("F71F4B9A-AA60-461D-B398-DE31001BF214")
             
                
            };

            admin.PasswordHash = CreatePasswordHash(admin, "223362");

            builder.HasData(admin);

              
         
        }

        private string CreatePasswordHash(BlogUser user, string password)
        {
            var passwordHasher = new PasswordHasher<BlogUser>();
            return passwordHasher.HashPassword(user, password);
        }


    }
}
