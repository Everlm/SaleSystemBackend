using Microsoft.AspNetCore.Mvc;
using SaleSystem.API.Commons.Base;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DTO.Dtos;

namespace SaleSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var response = new BaseResponse<List<UserDto>>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _userService.List();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = new BaseResponse<SessionDto>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _userService.ValidateCredentials(loginDto.Email, loginDto.Password);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            var response = new BaseResponse<UserDto>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _userService.Create(userDto);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] UserDto userDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _userService.Edit(userDto);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.IsSuccess = true;
                response.Data = await _userService.Delete(id);

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
