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
    public class ImageService : IImageService
    {
        private readonly IMapper _mapper;
        private readonly IImageDal _imageDal;

        public ImageService(IMapper mapper , IImageDal imageDal)
        {
            _mapper = mapper ; _imageDal = imageDal;
        }
        public async Task AddAsyncService(ImageDto Entity)
        {
            var image = _mapper.Map<Image>(Entity);
            await _imageDal.AddAsync(image);
        }

        public Task<bool> AnyAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsyncService(ImageDto Entity)
        {
            var image = _mapper.Map<Image>(Entity) ;
            await _imageDal.DeleteAsync(image);
        }

        public Task<List<ImageDto>> GetAllAsyncService()
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> GetAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> GetByGuidAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> UpdateAsyncService(ImageDto Entity)
        {
            throw new NotImplementedException();
        }
    }
}
