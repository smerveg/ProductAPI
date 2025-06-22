using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Extension
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationExtensions(this IServiceCollection services) 
        {
            var asm = Assembly.GetExecutingAssembly();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(asm));
            return services;
        }
    }
}
