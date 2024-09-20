using EmircanBlog_Data.Context;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Data.Repositories.Concrete;
using EmircanBlog_Data.UnitOfWorks;
using EmircanBlog_Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.DataExtensions
{
    public static class DALExtensions 
    {
        public static IServiceCollection LoadDALExtensions(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IArticleDal, ArticleDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IImageDal, ImageDal>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddDbContext<EmircanContext>();
            services.AddIdentity<BlogUser,BlogRole>().AddEntityFrameworkStores<EmircanContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
