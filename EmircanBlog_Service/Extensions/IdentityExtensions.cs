using EmircanBlog_Data.Context;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Extensions
{
    public static class IdentityExtensions
    {
       
       public static async Task<BlogUser> GetUserWithIncludesAsync(this UserManager<BlogUser> userManager, ClaimsPrincipal user , IImageService imageService)
        {
            var User = await userManager.GetUserAsync(user);

            User.Image = await imageService.GetImageByUserId(User.Id);
            return User;
        }
    }
}
