using SaleSystem.DTO.Dtos;

namespace SaleSystem.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> List();
    }
}
