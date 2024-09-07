using AutoMapper;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.ViewModels;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ArticleListController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        private readonly UserManager<BlogUser> _userManager;

        public ArticleListController(IArticleService articleService,IMapper mapper , UserManager<BlogUser> userManager)
        {
            _articleService = articleService;
            _mapper = mapper;
            _userManager = userManager;
           
        }
        public async Task<IActionResult> Index()
        {
      
            var blogUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var articles = await _articleService.GetAllAsyncService();
            var articleViewModel = _mapper.Map<List<ArticleListViewModel>>(articles);
            return View(articleViewModel);
        }

        public async Task<IActionResult> DeleteArticle(Guid id)
        {
         
            await _articleService.DeleteAsyncService(id);
            return RedirectToAction("Index", "ArticleList", new { Area = "Admin" });
        }
    }
}
