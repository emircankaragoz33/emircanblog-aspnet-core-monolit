using AutoMapper;
using EmircanBlog_Entity.ViewModels;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleListController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleListController(IArticleService articleService,IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllAsyncService();
            var articleViewModel = _mapper.Map<List<ArticleListViewModel>>(articles);
            return View(articleViewModel);
        }
    }
}
