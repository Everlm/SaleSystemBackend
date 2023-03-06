using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.Utilities.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.RoleDescription, opt => opt.MapFrom(o => o.Role!.Name))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(o => o.IsActive == true ? 1 : 0));

            CreateMap<User, SessionDto>()
                .ForMember(d => d.RoleDescription, opt => opt.MapFrom(o => o.Role!.Name));

            CreateMap<UserDto, User>()
                .ForMember(d => d.Role, opt => opt.Ignore())
                .ForMember(d => d.IsActive, opt => opt.MapFrom(o => o.IsActive == 1 ? true : false));
        }
    }
}
