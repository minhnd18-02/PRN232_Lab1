using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.ViewModels.Products
{
    public class ProductInMenuResponse
    {
        public int ProductInMenuId { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
    }
}
