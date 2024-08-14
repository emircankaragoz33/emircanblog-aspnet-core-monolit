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
    public class ImageService : IImageService
    {
        private readonly GenericRepository<Image> _repository;
        public ImageService(GenericRepository<Image> repository)
        {
            _repository = repository;
        }
        public async Task AddAsyncService(Image Entity)
        {
            await _repository.AddAsync(Entity);
        }

        public async Task<bool> AnyAsyncService(Expression<Func<Image, bool>> filter = null)
        {
            return await _repository.AnyAsync(filter);
        }

        public async Task<int> CountAsyncService(Expression<Func<Image, bool>> filter = null)
        {
            return await _repository.CountAsync(filter);
        }

        public async Task DeleteAsyncService(Image Entity)
        {
            await _repository.DeleteAsync(Entity);
        }

        public async Task<List<Image>> GetAllAsyncService(Expression<Func<Image, bool>> filter = null, params Expression<Func<Image, object>>[] includePropereties)
        {
            return await _repository.GetAllAsync(c => c.Id != null);
        }

        public async Task<Image> GetAsyncService(Expression<Func<Image, bool>> filter = null, params Expression<Func<Image, object>>[] includeProperties)
        {
            return await _repository.GetAsync(c => c.Id != null);
        }

        public async Task<Image> GetByGuidAsyncService(Guid id)
        {
            return await _repository.GetByGuidAsync(id);
        }

        public async Task<Image> UpdateAsyncService(Image Entity)
        {
            return await _repository.UpdateAsync(Entity);
        }
    }
}
