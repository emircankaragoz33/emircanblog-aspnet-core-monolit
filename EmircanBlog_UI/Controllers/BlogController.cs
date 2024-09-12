using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;   
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var article = await _articleService.GetAsyncService(id);
            return View(article);
        }
    }
}
