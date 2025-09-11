using PRN232.Lab1.CoffeeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.IServices
{
    public interface IMenuSerivce
    {
        public Task<IEnumerable<Menu>> GetMenus();
        public Task<Menu> GetMenu(int id);
        public Task<Menu> AddMenu(Menu menu);
        public Task<Menu> UpdateMenu(Menu menu);
        public Task<int> DeleteMenu(int id);

    }
}
