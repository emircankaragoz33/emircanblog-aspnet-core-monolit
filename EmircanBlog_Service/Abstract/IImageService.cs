using EmircanBlog_Data.Repositories.Abstract;
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
    public interface IImageService
    {
        public Task AddAsyncService(Image Entity);

        public Task<bool> AnyAsyncService(Guid id);

        public  Task DeleteAsyncService(Image Entity);

        public Task<List<Image>> GetAllAsyncService(Guid UserId);


        public Task<Image> GetAsyncService(Guid id);


        public Task<Image> GetByGuidAsyncService(Guid id);



        public Task<Image> UpdateAsyncService(Image Entity);

        public Task<Image> GetImageByUserId(Guid id);


    }
}
