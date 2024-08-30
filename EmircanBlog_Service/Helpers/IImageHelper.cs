using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Helpers
{
    public interface IImageHelper
    {
        Task<ImageDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
