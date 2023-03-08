using Microsoft.AspNetCore.Mvc;
using SaleSystem.API.Commons.Base;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DTO.Dtos;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var response = new BaseResponse<List<RoleDto>>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _roleService.List();

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
