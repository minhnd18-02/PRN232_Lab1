using PRN232.Lab1.CoffeeStore.Application.ServiceResponse;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Products;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.IServices
{
    public interface IProductService
    {
        public Task<ServiceResponse<IEnumerable<ProductResponse>>> GetProducts();
        public Task<ServiceResponse<ProductResponse>> GetProductById(int id);
        public Task<ServiceResponse<ProductResponse>> AddProduct(CreateProductRequest product);
        public Task<ServiceResponse<ProductResponse>> UpdateProduct(UpdateProductRequest product);
        public Task<ServiceResponse<int>> DeleteProduct(int id);
        public Task<ServiceResponse<PaginationModel<ProductResponse>>> GetProductsPaging(int pageNumber, int pageSize);
    }
}
