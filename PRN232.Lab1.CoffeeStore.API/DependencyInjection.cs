using PRN232.Lab1.CoffeeStore.Application.IServices;
using PRN232.Lab1.CoffeeStore.Application.Services;

namespace PRN232.Lab1.CoffeeStore.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService (this IServiceCollection services)
        {
            services.AddScoped<IMenuSerivce, MenuService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
