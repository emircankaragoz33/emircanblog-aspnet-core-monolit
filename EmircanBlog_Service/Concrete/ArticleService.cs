using AutoMapper;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Data.Repositories.Concrete;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace EmircanBlog_Service.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleDal _articleDal;
        private readonly IMapper _mapper;
        public ArticleService(IArticleDal articleDal , IMapper mapper)
        {
            _articleDal = articleDal;
            _mapper = mapper;
        }
        public async Task AddAsyncService(ArticleDto Entity)
        {
            
            var article =  _mapper.Map<Article>(Entity);
            await _articleDal.AddAsync(article);

        }

        public async Task<bool> AnyAsyncService(Guid id)
        {
            var article = await _articleDal.GetByGuidAsync(id);
            return await _articleDal.AnyAsync(c=>c.Id == id);

        }

        //public async Task<int> CountAsyncService(Guid id)
        //{
        //  var countFilter = _mapper.Map<Expression<Func<Article, int>>>(filter);
        //    return await _articleDal.CountAsync(countFilter);
        //}

        public async Task DeleteAsyncService(ArticleDto Entity)
        {
            var article = _mapper.Map<Article>(Entity);
            await _articleDal.DeleteAsync(article);

        }

        public async Task<List<ArticleDto>> GetAllAsyncService()
        {
            var articles = await _articleDal.GetAllAsync(c=>c.IsDeleted == false);

            var articleDtos = _mapper.Map<List<ArticleDto>>(articles);
            return articleDtos;
        }

        public async Task<ArticleDto> GetAsyncService(Guid id)
        {

            var article = await _articleDal.GetAsync(c=>c.Id == id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return articleDto;


        }

        public async Task<ArticleDto> GetByGuidAsyncService(Guid id)
        {
            var article = await _articleDal.GetByGuidAsync(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return articleDto;
        }

        public async Task<ArticleDto> UpdateAsyncService(ArticleDto Entity)
        {
            var article = _mapper.Map<Article>(Entity);
            var articleUpdate = await _articleDal.UpdateAsync(article);
            var map = _mapper.Map<ArticleDto>(articleUpdate);
            return map;
        }
    }
}
