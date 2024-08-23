using AutoMapper;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.ViewModels;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService , IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var categories = await _categoryService.GetAllAsyncService();
            CategoryViewModel model = new CategoryViewModel();
            model.Categories = categories;

            return View(model);

        }

        [HttpPost]
        public async Task <IActionResult> Index(CategoryViewModel categoryViewModel)
        {
            var categoryDto =  _mapper.Map<CategoryDto>(categoryViewModel);

           await _categoryService.AddAsyncService(categoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
