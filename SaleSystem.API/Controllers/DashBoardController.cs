using Microsoft.AspNetCore.Mvc;
using SaleSystem.API.Commons.Base;
using SaleSystem.BLL.Interfaces;
using SaleSystem.BLL.Services;
using SaleSystem.DTO.Dtos;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _service;

        public DashBoardController(IDashBoardService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetDashBoard")]
        public async Task<IActionResult> GetDashBoard()
        {
            var response = new BaseResponse<DashBoardDto>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _service.GetDashBoard();

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
