using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Application.IServices;
using PRN232.Lab1.CoffeeStore.Application.Services;
using PRN232.Lab1.CoffeeStore.Application.ViewModels.Menus;
using PRN232.Lab1.CoffeeStore.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuSerivce _menuService;
        public MenuController(IMenuSerivce menuSerivce)
        {
            _menuService = menuSerivce;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            var result = await _menuService.GetMenus();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{menuId}")]
        public async Task<IActionResult> GetMenuById(int menuId)
        {
            var result = await  _menuService.GetMenu(menuId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] CreateMenuRequest menu)
        {
            var result = await _menuService.AddMenu(menu);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{menuId}")]
        public async Task<IActionResult> UpdateMenu(int menuId, [FromBody] UpdateMenuRequest menu)
        {
            var result = await _menuService.UpdateMenu(menuId, menu);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{menuId}")]
        public async Task<IActionResult> DeleteMenu(int menuId)
        {
            var result = await _menuService.DeleteMenu(menuId);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
