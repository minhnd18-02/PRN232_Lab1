using PRN232.Lab1.CoffeeStore.Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application
{
    public interface IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; }
        public IMenuRepo MenuRepo { get; }
        public IProductInMenuRepo ProductInMenuRepo { get; }
        public IProductRepo ProductRepo { get; }

        public Task<int> SaveChangeAsync();
    }
}
