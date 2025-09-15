using PRN232.Lab1.CoffeeStore.Application;
using PRN232.Lab1.CoffeeStore.Application.IRepositories;
using PRN232.Lab1.CoffeeStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryRepo _categoryRepo;

        private readonly IMenuRepo _menuRepo;

        private readonly IProductInMenuRepo _productInMenuRepo;

        private readonly IProductRepo _productRepo;

        public UnitOfWork(AppDbContext appDbContext,ICategoryRepo categoryRepo, IMenuRepo menuRepo, IProductInMenuRepo productInMenuRepo, IProductRepo productRepo)
        {
            _appDbContext = appDbContext;   
            _categoryRepo = categoryRepo;
            _menuRepo = menuRepo;
            _productRepo = productRepo;
            _productInMenuRepo = productInMenuRepo;
        }

        public ICategoryRepo CategoryRepo => _categoryRepo;
        public IMenuRepo MenuRepo => _menuRepo;
        public IProductRepo ProductRepo => _productRepo;
        public IProductInMenuRepo ProductInMenuRepo => _productInMenuRepo;
        public async Task<int> SaveChangeAsync()
        {
            try
            {
                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while saving changes.", ex);
            }
        }
    }
}
