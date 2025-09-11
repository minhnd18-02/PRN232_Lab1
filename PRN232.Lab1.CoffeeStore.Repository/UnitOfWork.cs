using PRN232.Lab1.CoffeeStore.Application;
using PRN232.Lab1.CoffeeStore.Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICategoryRepo _categoryRepo;

        private readonly IMenuRepo _menuRepo;

        private readonly IProductInMenuRepo _productInMenuRepo;

        private readonly IProductRepo _productRepo;

        public UnitOfWork(ICategoryRepo categoryRepo, IMenuRepo menuRepo, IProductInMenuRepo productInMenuRepo, IProductRepo productRepo)
        {
            _categoryRepo = categoryRepo;
            _menuRepo = menuRepo;
            _productRepo = productRepo;
            _productInMenuRepo = productInMenuRepo;
        }

        public ICategoryRepo CategoryRepo => _categoryRepo;
        public IMenuRepo MenuRepo => _menuRepo;
        public IProductRepo ProductRepo => _productRepo;
        public IProductInMenuRepo ProductInMenuRepo => _productInMenuRepo;
        public Task<int> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
