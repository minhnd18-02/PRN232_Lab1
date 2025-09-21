using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.ViewModels.Products
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "ProductName is required")]
        [StringLength(20, ErrorMessage = "ProductName can't be longer than 20 characters")]
        public string ProductName { get; set; } = string.Empty;
        [StringLength(50, ErrorMessage = "ProductName can't be longer than 50 characters")]
        public string ProductDescription { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        [Required(ErrorMessage = "CategoryId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive integer")]
        public int CategoryId { get; set; }

    }
}
