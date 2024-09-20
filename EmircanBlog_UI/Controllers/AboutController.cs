using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Controllers
{


    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
