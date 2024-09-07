using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.ViewComponents
{
    public class LastArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public LastArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;   
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var lastArticles =  await _articleService.GetAllAsyncService();

            return View("LastArticles",lastArticles.OrderByDescending(c=>c.CreatedDate).Take(3).ToList());
        }
    }
}
