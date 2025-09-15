using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus
{
    public class UpdateProductInMenuRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
