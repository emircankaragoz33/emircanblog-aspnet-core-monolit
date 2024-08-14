using EmircanBlog_Data.Context;
using Microsoft.EntityFrameworkCore;
using EmircanBlog_Data.DataExtensions;
using EmircanBlog_Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.LoadDALExtensions(builder.Configuration);
builder.Services.LoadServiceExtensions();
builder.Services.AddDbContext<EmircanContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "admin/{controller = Home}/{action=Index}/{id}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
