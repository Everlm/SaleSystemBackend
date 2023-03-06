using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.Utilities.Mappers
{
    public class MenuMappingsProfile :Profile
    {
        public MenuMappingsProfile()
        {
            CreateMap<Menu, MenuDto>()
               .ReverseMap();
        }
    }
}
