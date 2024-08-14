using EmircanBlog_Data.Repositories.Concrete;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Concrete
{
    public class CategoryService : ICategoryService
    {

        private readonly GenericRepository<Category> _repository;
        public CategoryService(GenericRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task AddAsyncService(Category Entity)
        {
           await _repository.AddAsync(Entity);
        }

        public async Task<bool> AnyAsyncService(Expression<Func<Category, bool>> filter = null)
        {
         return await _repository.AnyAsync(filter);
        }

        public async Task<int> CountAsyncService(Expression<Func<Category, bool>> filter = null)
        {
           return await (_repository.CountAsync(filter));   
        }

        public async Task DeleteAsyncService(Category Entity)
        {
           await _repository.DeleteAsync(Entity);
        }

        public async Task<List<Category>> GetAllAsyncService(Expression<Func<Category, bool>> filter = null, params Expression<Func<Category, object>>[] includePropereties)
        {
           return await _repository.GetAllAsync(c => c.Id != null);
        }

        public async Task<Category> GetAsyncService(Expression<Func<Category, bool>> filter = null, params Expression<Func<Category, object>>[] includeProperties)
        {
            return await _repository.GetAsync(c => c.Id != null);
        }

        public async Task<Category> GetByGuidAsyncService(Guid id)
        {
            return await _repository.GetByGuidAsync(id);
        }

        public async Task<Category> UpdateAsyncService(Category Entity)
        {
            return await _repository.UpdateAsync(Entity);
        }
    }
}
