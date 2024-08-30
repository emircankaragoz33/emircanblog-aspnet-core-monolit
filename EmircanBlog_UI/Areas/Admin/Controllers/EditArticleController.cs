using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmircanBlog_Service.Abstract;
using AutoMapper;
using EmircanBlog_Entity.ViewModels;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Dtos.UpdateDtos;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EditArticleController : Controller
    {
        private readonly UserManager<BlogUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public EditArticleController(UserManager<BlogUser> userManager, IArticleService articleService , IMapper mapper)
        {
            _userManager = userManager;
            _articleService = articleService ;
            _mapper = mapper ;
        }

        [HttpGet]
        public async  Task<IActionResult> Index(Guid id)
        {
            var articleDto = await _articleService.GetAsyncService(id);
            var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(articleDto);

            return View(articleUpdateDto);
        }



        [HttpPost]
        public async Task<IActionResult> Index(ArticleUpdateDto articleModel)
        {
            await _articleService.UpdateAsyncServiceUpdateDto(articleModel);

            return RedirectToAction("Index", "ArticleList", new { Area = "Admin" });

        }


    }
}
