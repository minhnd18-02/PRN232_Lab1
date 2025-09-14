using Microsoft.Extensions.DependencyInjection;
using PRN232.Lab1.CoffeeStore.Application;
using PRN232.Lab1.CoffeeStore.Application.IRepositories;
using PRN232.Lab1.CoffeeStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IMenuRepo, MenuRepo>();
            services.AddScoped<IProductInMenuRepo, ProductInMenuRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            return services;
        }
    }
}
