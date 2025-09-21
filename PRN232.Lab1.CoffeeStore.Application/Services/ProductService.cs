using AutoMapper;
using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Application.IServices;
using PRN232.Lab1.CoffeeStore.Application.ServiceResponse;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Products;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<ProductResponse>> AddProduct(CreateProductRequest product)
        {
            var response = new ServiceResponse<ProductResponse>();
            try
            {
                var category = await _unitOfWork.CategoryRepo.GetByIdAsync(product.CategoryId);
                if (category == null)
                {
                    response.Success = false;
                    response.Message = "Category not found";
                    return response;
                }

                var newProduct = _mapper.Map<Product>(product);
                newProduct.CategoryId = product.CategoryId;

                await _unitOfWork.ProductRepo.AddAsync(newProduct);

                response.Success = true;
                response.Message = "Product added successfully";
                response.Data = _mapper.Map<ProductResponse>(newProduct);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<int>> DeleteProduct(int id)
        {
            var response = new ServiceResponse<int>();
            try
            {
                var product = await _unitOfWork.ProductRepo.GetByIdAsync(id);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Product not found";
                    return response;
                }

                await _unitOfWork.ProductRepo.RemoveAsync(product);

                response.Success = true;
                response.Message = "Product deleted successfully";
                response.Data = id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<ProductResponse>> GetProductById(int id)
        {
            var response = new ServiceResponse<ProductResponse>();
            try
            {
                var product = await _unitOfWork.ProductRepo.GetByIdWithMenusAsync(id);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Product not found";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Product retrieved successfully";
                    response.Data = _mapper.Map<ProductResponse>(product);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ProductResponse>>> GetProducts()
        {
            var response = new ServiceResponse<IEnumerable<ProductResponse>>();
            try
            {
                var products = await _unitOfWork.ProductRepo.GetAllWithMenusAsync();
                if (products != null && products.Any())
                {
                    response.Success = true;
                    response.Message = "Products retrieved successfully";
                    response.Data = _mapper.Map<IEnumerable<ProductResponse>>(products);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Products not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<PaginationModel<ProductResponse>>> GetProductsPaging(int pageNumber, int pageSize)
        {
            var response = new ServiceResponse<PaginationModel<ProductResponse>>();
            try
            {
                var products = await _unitOfWork.ProductRepo.GetAllWithMenusAsync();
                if (products != null && products.Any())
                {
                    var totalRecords = products.Count();
                    var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

                    var pagedProducts = products
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    var paginationModel = new PaginationModel<ProductResponse>
                    {
                        Page = pageNumber,
                        TotalPage = totalPages,
                        TotalRecords = totalRecords,
                        ListData = _mapper.Map<IEnumerable<ProductResponse>>(pagedProducts)
                    };

                    response.Success = true;
                    response.Message = "Products retrieved successfully";
                    response.Data = paginationModel;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Products not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<ProductResponse>> UpdateProduct(UpdateProductRequest product)
        {
            var response = new ServiceResponse<ProductResponse>();
            try
            {
                var checkId = await _unitOfWork.ProductRepo.GetByIdAsync(product.ProductId);
                if (checkId == null)
                {
                    response.Success = false;
                    response.Message = "ProductId not found";
                    return response;
                }

                var checkCate = await _unitOfWork.CategoryRepo.GetByIdAsync(product.CategoryId);
                if (checkCate == null)
                {
                    response.Success = false;
                    response.Message = "CategoryId not found";
                    return response;
                }

                var updateProduct = _mapper.Map(product, checkId);
                checkId.Category = checkCate;

                await _unitOfWork.ProductRepo.UpdateAsync(updateProduct);

                response.Success = true;
                response.Message = "Product updated successfully";
                response.Data = _mapper.Map<ProductResponse>(updateProduct);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }
    }
}
