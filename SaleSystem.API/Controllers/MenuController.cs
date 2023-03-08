using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystem.API.Commons.Base;
using SaleSystem.BLL.Interfaces;
using SaleSystem.BLL.Services;
using SaleSystem.DTO.Dtos;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(int userId)
        {
            var response = new BaseResponse<List<MenuDto>>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _menuService.List(userId);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
