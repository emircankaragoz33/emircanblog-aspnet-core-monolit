using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogsController(IArticleService articleService)
        {

            _articleService = articleService;
        }


        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllAsyncService();
            return View(articles);
        }
    }
}



