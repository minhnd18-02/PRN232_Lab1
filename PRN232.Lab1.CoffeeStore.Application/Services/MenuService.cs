using AutoMapper;
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
                await _unitOfWork.MenuRepo.AddAsync(newMenu);

                response.Success = true;
                response.Message = "Menu added successfully";
                response.Data = _mapper.Map<MenuResponse>(newMenu);
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
                var menu = await _unitOfWork.MenuRepo.GetByIdAsync(id);
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
                var menus = await _unitOfWork.MenuRepo.GetAllAsync();
                if (menus != null && menus.Any())
                {
                    response.Success = true;
                    response.Message = "Menus retrieved successfully";
                    response.Data = menus.Select(m => new MenuResponse
                    {
                        MenuId = m.MenuId,
                        MenuName = m.MenuName,
                        MenuFromDate = m.MenuFromDate,
                        MenuToDate = m.MenuToDate,
                    });
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
                var checkId = await _unitOfWork.MenuRepo.FindEntityAsync(m => m.MenuId == id);
                if (checkId == null)
                {
                    response.Success = false;
                    response.Message = "MenuId not found";
                    return response;
                }
                var updateMenu = _mapper.Map(menu, checkId);
                await _unitOfWork.MenuRepo.UpdateAsync(updateMenu);

                response.Success = true;
                response.Message = "Menu updated successfully";
                response.Data = _mapper.Map<MenuResponse>(updateMenu);
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
