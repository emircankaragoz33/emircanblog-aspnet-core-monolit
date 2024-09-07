using EmircanBlog_Entity.Entities;
using EmircanBlog_Service.Abstract;
using EmircanBlog_UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EmircanBlog_UI.Controllers
{
    public class HomeController : Controller
    {
  

        public HomeController()
        {
          
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

    
      
    }
}
