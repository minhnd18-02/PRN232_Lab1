using PRN232.Lab1.CoffeeStore.Application.IRepositories;
using PRN232.Lab1.CoffeeStore.Data;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Infrastructure.Repositories
{
    public class MenuRepo : GenericRepo<Menu>, IMenuRepo
    {
        public MenuRepo(AppDbContext context) : base(context)
        {
        }
    }
}
