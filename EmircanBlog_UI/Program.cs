using EmircanBlog_Data.DataExtensions;
using EmircanBlog_Service.Abstract;
using EmircanBlog_Service.Concrete;
using EmircanBlog_Service.Extensions;
using EmircanBlog_Service.FluentValidation.User;
using EmircanBlog_UI.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.LoadDALExtensions(builder.Configuration);
builder.Services.LoadServiceExtensions();

builder.Services.AddDistributedMemoryCache(); // İstemci tarafı oturumları için

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(30); // Oturumun zaman aşımını ayarlayın
    options.Cookie.HttpOnly = true; // Çerezlerin sadece HTTP üzerinden erişilebileceğini belirler
    options.Cookie.IsEssential = true; // Çerezin temel işlevler için gerekli olduğunu belirtir
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<LoginValidator>());


builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();  // HTTPS yönlendirmesi
app.UseStaticFiles();       // Statik dosyalar

app.UseRouting();           // Routing

app.UseMiddleware<VisitorMiddleware>(); // Middleware'ler (Ýstek yönlendirmesi yapýlmadan önce çalýþmalý)
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{

    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
