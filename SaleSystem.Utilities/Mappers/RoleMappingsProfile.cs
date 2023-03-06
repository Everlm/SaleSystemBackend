using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.Utilities.Mappers
{
    public class RoleMappingsProfile :Profile
    {
        public RoleMappingsProfile()
        {
            CreateMap<Role, RoleDto>()
                .ReverseMap();
        }
    }
}
