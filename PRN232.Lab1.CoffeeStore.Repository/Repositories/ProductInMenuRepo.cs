
using PRN232.Lab1.CoffeeStore.Application.IRepositories;
using PRN232.Lab1.CoffeeStore.Data;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Repositories.Repository;

namespace PRN232.Lab1.CoffeeStore.Infrastructure.Repositories
{
    public class ProductInMenuRepo : GenericRepo<ProductInMenu>, IProductInMenuRepo
    {
        public ProductInMenuRepo(AppDbContext context) : base(context)
        {
        }
    }
}
