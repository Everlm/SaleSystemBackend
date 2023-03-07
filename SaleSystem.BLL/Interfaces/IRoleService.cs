using SaleSystem.DTO.Dtos;

namespace SaleSystem.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> List();
       
    }
}
