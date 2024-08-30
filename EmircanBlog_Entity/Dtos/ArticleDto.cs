using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.Dtos
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }  
        public int? ViewCount { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public IFormFile formFile { get; set; }
        public Guid ImageId { get; set; }

        public Category category { get; set; }
    }
}
