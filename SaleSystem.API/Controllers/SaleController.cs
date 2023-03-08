using Microsoft.AspNetCore.Mvc;
using SaleSystem.API.Commons.Base;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DTO.Dtos;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] SaleDto saleDto)
        {
            var response = new BaseResponse<SaleDto>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _saleService.Register(saleDto);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetHistory")]
        public async Task<IActionResult> GetHistory(string findBy, string? saleNumber, string? startDate, string? endDate)
        {
            var response = new BaseResponse<List<SaleDto>>();

            saleNumber = saleNumber is null ? "" : saleNumber;
            startDate = startDate is null ? "" : startDate;
            endDate = endDate is null ? "" : endDate;

            try
            {
                response.IsSuccess = true;
                response.Data = await _saleService.GetHistory(findBy, saleNumber, startDate, endDate);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("ReportSale")]
        public async Task<IActionResult> ReportSale(string? startDate, string? endDate)
        {
            var response = new BaseResponse<List<ReportDto>>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _saleService.Report(startDate, endDate);

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
