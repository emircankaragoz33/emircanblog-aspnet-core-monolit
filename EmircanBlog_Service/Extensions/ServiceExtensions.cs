using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Data.Repositories.Concrete;
using EmircanBlog_Service.Abstract;
using EmircanBlog_Service.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Extensions
{
    public static class ServiceExtensions 
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
           

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
