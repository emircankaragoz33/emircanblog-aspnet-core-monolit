using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Service.Abstract;
using EmircanBlog_Service.Concrete;
using EmircanBlog_Service.Helpers;
using EmircanBlog_Entity.Enums;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly UserManager<BlogUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IImageHelper _imageHelper;

        public ProfileController(UserManager<BlogUser> userManager, IMapper mapper, IImageService imageService, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _imageService = imageService;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.name = user.UserName;
            user.Image = await _imageService.GetAsyncService(user.ImageId);

            var userDto = _mapper.Map<UserProfileDto>(user);
            return View(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserProfileDto userDto)
        {

 
            var currentUser = await _userManager.GetUserAsync(User);
            currentUser.Image = await _imageService.GetAsyncService(currentUser.ImageId);

            if (userDto.Photo != null)
            {
                var imageUpload = await _imageHelper.Upload(userDto.UserName, userDto.Photo, ImageType.User);

                Image image = new Image
                {
                    Id = Guid.NewGuid(),
                    FileName = imageUpload.FullName,
                    FileType = userDto.Photo.ContentType,
                    UserId = userDto.Id
                };
                await _imageService.AddAsyncService(image);
                userDto.ImageId = image.Id;
            }

            var user = _mapper.Map(userDto, currentUser);


            await _userManager.UpdateAsync(user);


            return RedirectToAction("Index", "Profile", new { Area = "Admin" });




        }
    }
}
