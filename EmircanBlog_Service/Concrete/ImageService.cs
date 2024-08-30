using AutoMapper;
using AutoMapper.Configuration.Annotations;
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
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Concrete
{
    public class ImageService : IImageService
    {
        private readonly IMapper _mapper;
        private readonly IImageDal _imageDal;
        private readonly IUnitOfWork _unitOfWork;
        
        public ImageService(IMapper mapper , IImageDal imageDal , IUnitOfWork unitOfWork)
        {
            _mapper = mapper ; _imageDal = imageDal; _unitOfWork = unitOfWork;
        }
        public async Task AddAsyncService(Image Entity)
        {
           
            await _imageDal.AddAsync(Entity);
            await _unitOfWork.SaveAsync();
        }

        public Task<bool> AnyAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsyncService(Image Entity)
        {
            var image = _mapper.Map<Image>(Entity) ;
            await _imageDal.DeleteAsync(image);
        }

        public Task<List<Image>> GetAllAsyncService(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetAsyncService(Guid id)
        {
            var image = await _imageDal.GetAsync(c=>c.Id == id);
            return image;
        }

        public Task<Image> GetByGuidAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Image> UpdateAsyncService(Image Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetImageByUserId(Guid id)
        {
         var image = await _imageDal.GetAsync(c=>c.UserId == id);
            return image;
        }
    }
}
