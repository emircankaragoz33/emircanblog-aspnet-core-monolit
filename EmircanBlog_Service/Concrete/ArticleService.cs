using EmircanBlog_Data.Repositories.Concrete;
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
        private readonly GenericRepository<Article> _repository;
        public ArticleService(GenericRepository<Article> repository)
        {
            _repository = repository;
        }
        public async Task AddAsyncService(Article Entity)
        {
            await _repository.AddAsync(Entity);
        }

        public async Task<bool> AnyAsyncService(Expression<Func<Article, bool>> filter = null)
        {
           return await _repository.AnyAsync(filter);
        }

        public async Task<int> CountAsyncService(Expression<Func<Article, bool>> filter = null)
        {
          return await _repository.CountAsync(filter);
        }

        public async Task DeleteAsyncService(Article Entity)
        {
           await _repository.DeleteAsync(Entity);
        }

        public async Task<List<Article>> GetAllAsyncService(Expression<Func<Article, bool>> filter = null, params Expression<Func<Article, object>>[] includePropereties)
        {
            return await _repository.GetAllAsync(c => c.Id != null, c => c.Image, c => c.Category);
        }

        public async Task<Article> GetAsyncService(Expression<Func<Article, bool>> filter = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            return await _repository.GetAsync(c => c.Id != null, c => c.Image, c => c.Category);
        }

        public async Task<Article> GetByGuidAsyncService(Guid id)
        {
           return await _repository.GetByGuidAsync(id);
        }

        public async Task<Article> UpdateAsyncService(Article Entity)
        {
            return await _repository.UpdateAsync(Entity);
        }
    }
}
