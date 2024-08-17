using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<BlogUser> _userManager;
        private readonly SignInManager<BlogUser> _signInManager;

        public AuthController(UserManager<BlogUser> userManager, SignInManager<BlogUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]   
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginViewModel.Email);

                if (user != null)
                {
                    user.SecurityStamp = Guid.NewGuid().ToString();
                  var result =   await _signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, userLoginViewModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }

                    else
                    {
                        ModelState.AddModelError("", "Eposta adresi veya şifrede sorun var.");
                        return View();
                    }

                }

                else
                {
                    ModelState.AddModelError("", "Eposta adresi veya şifrede sorun var.");
                    return View();
                }



            }



            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

     


    }
}
