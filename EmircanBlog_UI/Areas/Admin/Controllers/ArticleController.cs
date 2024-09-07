using AutoMapper;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.ViewModels;
using EmircanBlog_Service.Abstract;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
    
        private readonly UserManager<BlogUser> _userManager;
        private readonly ICategoryService _categoryService;
  

        public ArticleController(IArticleService articleService, IMapper mapper , UserManager<BlogUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _mapper = mapper;
            _userManager = userManager;
            _categoryService = categoryService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var blogUser = await _userManager.FindByNameAsync(User.Identity.Name);
          
            var categories = await _categoryService.GetAllAsyncService();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] ArticleViewModel articleViewModel)
        {
            var blogUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var articleDto = _mapper.Map<ArticleDto>(articleViewModel);
            articleDto.UserId = blogUser.Id;
            articleDto.CreatedBy = blogUser.FirstName + " " + blogUser.LastName;
     
            
            await _articleService.AddAsyncService(articleDto);

           

            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
