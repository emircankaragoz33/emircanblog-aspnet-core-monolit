using AutoMapper;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Dtos.UpdateDtos;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<ArticleDto, ArticleViewModel>().ReverseMap();
          
            CreateMap<ArticleListViewModel, ArticleDto>().ReverseMap();
            CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap();
            CreateMap<Article, ArticleUpdateDto>().ReverseMap();

      
      
        }

    }
}
