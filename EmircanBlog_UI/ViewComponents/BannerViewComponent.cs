using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public BannerViewComponent(IArticleService articleService)
        {
            _articleService = articleService;   
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _articleService.GetAllAsyncService();
            var last6articles = articles.OrderByDescending(c=>c.CreatedDate).Take(6).ToList();

            return View("Banner",last6articles);  
        }
    }
}
