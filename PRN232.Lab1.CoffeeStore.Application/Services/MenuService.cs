using AutoMapper;
using Azure.Core;
using PRN232.Lab1.CoffeeStore.Application.IServices;
using PRN232.Lab1.CoffeeStore.Application.ServiceResponse;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Application.Services
{
    public class MenuService : IMenuSerivce
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<MenuResponse>> AddMenu(CreateMenuRequest menu)
        {
            var response = new ServiceResponse<MenuResponse>();
            try
            {
                var newMenu = _mapper.Map<Menu>(menu);

                foreach (var p in menu.Products)
                {
                    var checkProductId = await _unitOfWork.ProductRepo.GetByIdAsync(p.ProductId);
                    if (checkProductId == null)
                    {
                        response.Success = false;
                        response.Message = "Product not found";
                        return response;
                    }
                    newMenu.ProductInMenus.Add(new ProductInMenu
                    {
                        ProductId = p.ProductId,
                        ProductQuantity = p.ProductQuantity
                    }); 
                }

                await _unitOfWork.MenuRepo.AddAsync(newMenu);
                var menuWithProducts = await _unitOfWork.MenuRepo.GetByIdWithMenusAsync(newMenu.MenuId);

                response.Success = true;
                response.Message = "Menu added successfully";
                response.Data = _mapper.Map<MenuResponse>(menuWithProducts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<int>> DeleteMenu(int id)
        {
            var response = new ServiceResponse<int>();
            try
            {
                var menu = await _unitOfWork.MenuRepo.GetByIdAsync(id);
                if (menu == null)
                {
                    response.Success = false;
                    response.Message = "Menu not found";
                    return response;
                }

                await _unitOfWork.MenuRepo.RemoveAsync(menu);

                response.Success = true;
                response.Message = "Menu deleted successfully";
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

        public async Task<ServiceResponse<MenuResponse>> GetMenu(int id)
        {
            var response = new ServiceResponse<MenuResponse>();
            try
            {
                var menu = await _unitOfWork.MenuRepo.GetByIdWithMenusAsync(id);
                if (menu == null)
                {
                    response.Success = false;
                    response.Message = "Menu not found";
                }
                else
                {
                    response.Success = true;
                    response.Message = "Menu retrieved successfully";
                    response.Data = _mapper.Map<MenuResponse>(menu);
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


        public async Task<ServiceResponse<IEnumerable<MenuResponse>>> GetMenus()
        {
            var response = new ServiceResponse<IEnumerable<MenuResponse>>();
            try
            {
                var menus = await _unitOfWork.MenuRepo.GetAllWithMenusAsync();
                if (menus != null && menus.Any())
                {
                    response.Success = true;
                    response.Message = "Menus retrieved successfully";
                    response.Data = _mapper.Map<IEnumerable<MenuResponse>>(menus);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Menus not found";
                }
            }catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<MenuResponse>> UpdateMenu(int id, UpdateMenuRequest menu)
        {
            var response = new ServiceResponse<MenuResponse>();
            try
            {
                var checkId = await _unitOfWork.MenuRepo.GetByIdWithMenusAsync(id);
                if (checkId == null)
                {
                    response.Success = false;
                    response.Message = "MenuId not found";
                    return response;
                }

                checkId.MenuName = menu.MenuName;
                checkId.MenuFromDate = menu.MenuFromDate;
                checkId.MenuToDate = menu.MenuToDate;

                //var checkExist = checkId.ProductInMenus.ToList();

                //foreach (var oldProduct in checkExist)
                //{
                //    if (menu.Products.Any(p => p.ProductId == oldProduct.ProductId))
                //    {
                //        await _unitOfWork.ProductInMenuRepo.RemoveAsync(oldProduct);
                //    }
                //}


                //foreach (var newProduct in menu.Products)
                //{
                //    var existing = checkExist
                //        .FirstOrDefault(p => p.ProductId == newProduct.ProductId);

                //    if (existing != null)
                //    {
                //        existing.ProductQuantity = newProduct.Quantity;
                //        await _unitOfWork.ProductInMenuRepo.UpdateAsync(existing);
                //    }
                //    else
                //    {
                //        checkId.ProductInMenus.Add(new ProductInMenu
                //        {
                //            ProductId = newProduct.ProductId,
                //            ProductQuantity = newProduct.Quantity,
                //            MenuId = checkId.MenuId,
                //        });
                //    }
                //}

                await _unitOfWork.MenuRepo.UpdateAsync(checkId);

                var menuResponse = await _unitOfWork.MenuRepo.GetByIdWithMenusAsync(id);

                response.Success = true;
                response.Message = "Menu updated successfully";
                response.Data = _mapper.Map<MenuResponse>(menuResponse);
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
