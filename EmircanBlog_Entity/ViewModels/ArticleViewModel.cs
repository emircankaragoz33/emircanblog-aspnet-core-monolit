using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.ViewModels
{
    public class ArticleViewModel
    {
        public string ArticleTitle { get; set; }
        public string ArticleCategory { get; set; }
        public string ArticleContent { get; set; }
        public IFormFile ArticleFile { get; set; }
    }
}
