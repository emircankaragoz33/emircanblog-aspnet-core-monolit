using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.Dtos
{
    public class ArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? ViewCount { get; set; }
        public Guid CategoryId { get; set; }

        public Guid ImageId { get; set; }
    }
}
