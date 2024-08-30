using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    public class AuthController : Controller
    {

        private readonly SignInManager<BlogUser> _signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<BlogUser> _userManager;
        private readonly IValidator<LoginViewModel> _validator;

        public AuthController(SignInManager<BlogUser> signInManager, UserManager<BlogUser> _userManager, IValidator<LoginViewModel> validator)
        {
            _signInManager = signInManager;
            this._userManager = _userManager;
            _validator = validator;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Şifre yanlış.");
                        return View(loginModel);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "E-posta adresi bulunamadı.");
                    return View(loginModel);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                return View();
            }
        }


        [HttpGet]

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {

            if (registerModel.Password == registerModel.ConfirmPassword)
            {
                try
                {
                    BlogUser blogUser = new BlogUser()
                    {
                        Email = registerModel.Email,
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        UserName = registerModel.FirstName + registerModel.LastName,


                    };

                    var result = await _userManager.CreateAsync(blogUser, registerModel.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }

                    if (!ModelState.IsValid)
                    {
                        // Model doğrulama hatalarını ele al
                        return View(registerModel);
                    }

                    return View(registerModel);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            else
            {
                throw new Exception("Şifreler aynı olmalı.");
            }

        }


        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth", new { Area = "Admin" });
        }
    }
}
