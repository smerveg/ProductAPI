using Microsoft.Extensions.DependencyInjection;
using ProductApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductApp.Application.Repositories;
using ProductApp.Persistence.Repositories;

namespace ProductApp.Persistence.Extension
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistenceExtensions(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<ProductContext>(options => options.UseNpgsql
            (config.GetConnectionString("Product")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
