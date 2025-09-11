using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Data.Entities
{
    public class ProductInMenu
    {
        public int ProductInMenuId { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
        public int MenuId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Menu Menu { get; set; } = null!;
    }
}
