using EmircanBlog_Data.Repositories.Concrete;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Abstract
{
    public interface IArticleService  : IGenericService<ArticleDto>
    {

    }
}
