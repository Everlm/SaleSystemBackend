using SaleSystem.DTO.Dtos;

namespace SaleSystem.BLL.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> List();
        Task<SessionDto> ValidateCredentials(string email, string password);
        Task<UserDto> Create(UserDto user);
        Task<bool> Edit(UserDto user);
        Task<bool> Delete(int id);
    }
}
