using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Entity.ViewModels
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
