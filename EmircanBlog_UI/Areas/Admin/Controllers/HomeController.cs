<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> servisler yazıldı mapper eklendi.

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
<<<<<<< HEAD
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
=======
    public class HomeController : Controller
    {
>>>>>>> servisler yazıldı mapper eklendi.
        public IActionResult Index()
        {
            return View();
        }
    }
}
