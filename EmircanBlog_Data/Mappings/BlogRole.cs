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
    public class BlogRoleMap : IEntityTypeConfiguration<BlogRole>
    {
        public void Configure(EntityTypeBuilder<BlogRole> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("AspNetRoles");

            builder.HasData(new BlogRole()
            {
                Id = Guid.Parse("{638FABA6-2ABF-408E-9CCC-58C2C9A4F8FC}"),
                Name = "Admin",

            });

            builder.HasData(new BlogRole()
            {
                Id = Guid.Parse("{7F2B3DB2-4450-4155-B3EB-0539523ECBAE}"),
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });


        }
    }
}
