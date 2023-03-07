using SaleSystem.DTO.Dtos;

namespace SaleSystem.BLL.Interfaces
{
    public interface IDashBoardService
    {
        Task<DashBoardDto> GetDashBoard();
    }
}
