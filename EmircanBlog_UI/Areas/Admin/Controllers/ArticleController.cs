using AutoMapper;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.ViewModels;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] ArticleViewModel articleViewModel)
        {
            var articleDto = _mapper.Map<ArticleDto>(articleViewModel);
            await _articleService.AddAsyncService(articleDto);
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
