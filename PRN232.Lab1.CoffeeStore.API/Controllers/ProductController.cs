using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Application.IServices;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetProducts();
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging(int pageNumber, int pageSize)
        {
            var result = await _productService.GetProductsPaging(pageNumber, pageSize);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var result = await _productService.GetProductById(productId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductRequest createProductRequest)
        {
            var result = await _productService.AddProduct(createProductRequest);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }       

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var result = await _productService.UpdateProduct(updateProductRequest);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await _productService.DeleteProduct(productId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
