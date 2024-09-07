using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.ViewComponents
{
    public class RandomArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public RandomArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;   
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var articles = await _articleService.GetAllAsyncService();
            var random3Articles = articles.OrderBy(c => Guid.NewGuid()).Take(3).ToList();
            return View("RandomArticles",random3Articles);

        }
    }
}
