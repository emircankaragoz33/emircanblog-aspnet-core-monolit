using AutoMapper;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.ViewModels;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
     
        private readonly UserManager<BlogUser> _userManager;

        public CategoryController(ICategoryService categoryService , IMapper mapper , UserManager<BlogUser> userManager)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _userManager = userManager;
         
    } 
        [HttpGet]
        public async Task<IActionResult> Index() 
        {

            var blogUser = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["UserId"] = blogUser.Id.ToString();
            var categories = await _categoryService.GetAllAsyncService();
            CategoryViewModel model = new CategoryViewModel();
            model.Categories = categories;

            return View(model);

        }

        [HttpPost]
        public async Task <IActionResult> Index(CategoryViewModel categoryViewModel)
        {
            var categoryDto = _mapper.Map<CategoryDto>(categoryViewModel);
            categoryDto.UserId = (Guid)TempData["UserId"];
           await _categoryService.AddAsyncService(categoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }


        public async Task<IActionResult> DeleteCategory(Guid id)
        {
       
            await _categoryService.DeleteAsyncService(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
