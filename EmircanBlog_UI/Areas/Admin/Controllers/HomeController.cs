using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IVisitorService _visitorService;
        public HomeController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var totalVisitors = await _visitorService.GetVisitorCountAsync();
            ViewData["TotalVisitors"] = totalVisitors;
            return View();
        }
    }
}
