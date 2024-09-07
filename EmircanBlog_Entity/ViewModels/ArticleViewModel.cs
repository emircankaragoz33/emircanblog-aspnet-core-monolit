using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.ViewModels
{
    public class ArticleViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }

        public string Description {  get; set; }    
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ImageId { get; set; }
        public IFormFile formFile { get; set; }

        public Guid UserId { get; set; }
    }
}
