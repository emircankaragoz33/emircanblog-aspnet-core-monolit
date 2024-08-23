using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.ViewModels
{
    public class ArticleListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

         public  string CreatedBy { get; set; }
        public  string ModifiedBy { get; set; }
        public  string DeletedBy { get; set; }
      
        public Guid ImageId { get; set; }

     

    }
}
