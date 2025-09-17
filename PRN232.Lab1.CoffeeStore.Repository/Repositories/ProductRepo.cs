
using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Application.IRepositories;
using PRN232.Lab1.CoffeeStore.Data;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Repositories.Repository;


namespace PRN232.Lab1.CoffeeStore.Infrastructure.Repositories
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllWithMenusAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdWithMenusAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }
    }
}
