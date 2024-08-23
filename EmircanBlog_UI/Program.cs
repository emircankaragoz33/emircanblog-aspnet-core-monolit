using EmircanBlog_Data.DataExtensions;
using EmircanBlog_Service.Abstract;
using EmircanBlog_Service.Concrete;
using EmircanBlog_Service.Extensions;
using EmircanBlog_UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.LoadDALExtensions(builder.Configuration);
builder.Services.LoadServiceExtensions();


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


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
