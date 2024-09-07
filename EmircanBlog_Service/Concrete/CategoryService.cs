using AutoMapper;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Data.Repositories.Concrete;
using EmircanBlog_Data.UnitOfWorks;
using EmircanBlog_Entity.Dtos;
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
        private readonly IMapper _mapper;
        private readonly ICategoryDal _categoryDal;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryDal categoryDal, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsyncService(CategoryDto Entity)
        {
            try
            {
                var category = _mapper.Map<Category>(Entity);
                await _categoryDal.AddAsync(category);
                await _unitOfWork.SaveAsync();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<bool> AnyAsyncService(Guid id)
        {
           return await _categoryDal.AnyAsync(C=>C.Id == id);
        }

        public async Task DeleteAsyncService(Guid id)
        {
            var category = await _categoryDal.GetByGuidAsync(id);
            await _categoryDal.DeleteAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<CategoryDto>> GetAllAsyncService()
        {
            var categories = await _categoryDal.GetAllAsync(c=>c.IsDeleted == false );
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDto> GetAsyncService(Guid id)
        {
            var category = await _categoryDal.GetAsync(c => c.Id == id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<CategoryDto> GetByGuidAsyncService(Guid id)
        {
            var category = await _categoryDal.GetByGuidAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<CategoryDto> UpdateAsyncService(CategoryDto Entity)
        {
            var category = _mapper.Map<Category>(Entity);
            var categoryUpdate = await _categoryDal.UpdateAsync(category);
            var map = _mapper.Map<CategoryDto>(categoryUpdate);

            return map;

        }
    }
}
