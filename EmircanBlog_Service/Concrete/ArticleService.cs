using AutoMapper;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Data.Repositories.Concrete;
using EmircanBlog_Data.UnitOfWorks;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Dtos.UpdateDtos;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.Enums;
using EmircanBlog_Service.Abstract;
using EmircanBlog_Service.Helpers;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        private readonly IImageService _imageService;
        public ArticleService(IArticleDal articleDal , IMapper mapper , IUnitOfWork unitOfWork , IImageHelper imageHelper , IImageService imageService)
        {
            _articleDal = articleDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _imageHelper = imageHelper;
        }
        public async Task AddAsyncService(ArticleDto Entity)
        {
            var imageUpload = await _imageHelper.Upload(Entity.Title, Entity.formFile, ImageType.Post);
            Image image = new()
            {
                FileName = imageUpload.FullName,
                FileType = Entity.formFile.ContentType,
                UserId = Entity.UserId
            };

            await _imageService.AddAsyncService(image);


            var article =  _mapper.Map<Article>(Entity);
            article.IsDeleted = false;
            article.CreatedDate = DateTime.Now;
            article.ImageId = image.Id;
            await _articleDal.AddAsync(article);
            await _unitOfWork.SaveAsync();

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

        public async Task DeleteAsyncService(Guid id)
        {
          var article =   await _articleDal.GetByGuidAsync(id);
            await _articleDal.DeleteAsync(article);
            await _unitOfWork.SaveAsync();

        }

        public async Task<List<ArticleDto>> GetAllAsyncService()
        {
            var articles = await _articleDal.GetAllAsync(c=>c.IsDeleted == false , c=>c.Category , c=>c.Image);

            var articleDtos = _mapper.Map<List<ArticleDto>>(articles);
            return articleDtos;
        }

        public async Task<ArticleDto> GetAsyncService(Guid id)
        {

            var article = await _articleDal.GetAsync(c=>c.Id == id , c=>c.Category , c=>c.User , c=>c.Image);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return articleDto;


        }

        public async Task<ArticleDto> GetByGuidAsyncService(Guid id)
        {
            var article = await _articleDal.GetByGuidAsync(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return articleDto;
        }

        public Task<ArticleDto> UpdateAsyncService(ArticleDto Entity)
        {
            throw new NotImplementedException();
        }


        public async Task<List<ArticleDto>> GetAllWithCategoryAsync(Guid CategoryId)
        {
            var articles = await _articleDal.GetAllAsync( c => c.CategoryId == CategoryId);
            var articleDtos = _mapper.Map<List<ArticleDto>>(articles);
            return articleDtos;
        }

        public async Task<ArticleUpdateDto> UpdateAsyncServiceUpdateDto(ArticleUpdateDto Entity)
        {
            var article = await _articleDal.GetByGuidAsync(Entity.Id);

            var articleEntity = _mapper.Map(Entity, article);

           var updatedEntity =  await _articleDal.UpdateAsync(articleEntity);

            await _unitOfWork.SaveAsync();

            var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(updatedEntity);

            return articleUpdateDto;
            

           
        }
    }
}
