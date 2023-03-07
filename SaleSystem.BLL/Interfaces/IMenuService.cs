using SaleSystem.DTO.Dtos;

namespace SaleSystem.BLL.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuDto>> List(int userId);
    }
}
