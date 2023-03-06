using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.Utilities.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {
            CreateMap<Category, CategoryDto>()
              .ReverseMap();
        }
    }
}
