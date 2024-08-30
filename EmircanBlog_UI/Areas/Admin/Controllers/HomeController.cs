using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EmircanBlog_Entity.ViewModels;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IVisitorService _visitorService;
        private readonly IArticleService _articleService;
        private readonly UserManager<BlogUser> _userManager;
        private readonly IMapper _mapper;
        public HomeController(IVisitorService visitorService , IArticleService articleService, UserManager<BlogUser> userManager , IMapper mapper)
        {
            _visitorService = visitorService;
            _articleService = articleService;
            _userManager = userManager;
            _mapper = mapper;   
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await  _userManager.GetUserAsync(User);
            var articles = await _articleService.GetAllAsyncService(user.Id);
            var articlesListModel = _mapper.Map<List<ArticleListViewModel>>(articles);

            var totalVisitors = await _visitorService.GetVisitorCountAsync();
            ViewData["TotalVisitors"] = totalVisitors;
            return View(articlesListModel.OrderBy(c=>c.CreatedDate).Take(10).ToList());
        }
    }
}
