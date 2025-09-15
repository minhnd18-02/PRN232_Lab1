using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus
{
    public class CreateMenuRequest
    {
        public string MenuName { get; set; } = string.Empty;
        public DateTime MenuFromDate { get; set; }
        public DateTime MenuToDate { get; set; }
        
        public List<AddProductInMenuRequest> Products { get; set; } = new List<AddProductInMenuRequest>();
    }
}
