using AutoMapper;
using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<BlogUser> userManager;
        private readonly IMapper mapper;

        public DashboardHeaderViewComponent(UserManager<BlogUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));

            return View(loggedInUser);
        }
    }
}
