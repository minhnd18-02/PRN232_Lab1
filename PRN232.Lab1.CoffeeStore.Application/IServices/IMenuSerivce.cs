using PRN232.Lab1.CoffeeStore.Application.ServiceResponse;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
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
        Task<ServiceResponse<IEnumerable<MenuResponse>>> GetMenus();
        Task<ServiceResponse<MenuResponse>> GetMenu(int id);
        Task<ServiceResponse<MenuResponse>> AddMenu(CreateMenuRequest menu);
        Task<ServiceResponse<MenuResponse>> UpdateMenu(int id, UpdateMenuRequest menu);
        Task<ServiceResponse<int>> DeleteMenu(int id);

    }
}
