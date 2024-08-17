using EmircanBlog_Data.Context;
using Microsoft.EntityFrameworkCore;
using EmircanBlog_Data.DataExtensions;
using EmircanBlog_Service.Extensions;
using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmircanContext>();
builder.Services.LoadDALExtensions(builder.Configuration);
builder.Services.LoadServiceExtensions();



builder.Services.AddSession();


builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder()
    {
        Name = "EmircanBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };

    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(14);
    config.AccessDeniedPath = "/Admin/Auth/AccessDenied";
});



builder.Services.AddIdentity<BlogUser,BlogRole>(option=>
{
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;  
    option.Password.RequireLowercase = false;   
}).AddRoleManager<RoleManager<BlogRole>>().AddEntityFrameworkStores<EmircanContext>().AddDefaultTokenProviders();    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
