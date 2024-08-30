using EmircanBlog_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.Entities
{
    public class Image : EntityBase
    {
      
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<BlogUser> Users { get; set; }
        public Guid UserId { get; set; }

        
       

    }
}
