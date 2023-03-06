using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;
using System.Globalization;

namespace SaleSystem.Utilities.Mappers
{
    public class ProductMappingsProfile : Profile
    {
        public ProductMappingsProfile()
        {
            CreateMap<Product, ProductDto>()
             .ForMember(d => d.CategoryDescription, opt => opt.MapFrom(o => o.Category.Name))
             .ForMember(d => d.Price, opt => opt.MapFrom(o => Convert.ToString(o.Price.Value, new CultureInfo("es-CO"))))
             .ForMember(d => d.IsActive, opt => opt.MapFrom(o => o.IsActive == true ? 1 : 0));

            CreateMap<ProductDto, Product>()
            .ForMember(d => d.Category, opt => opt.Ignore())
            .ForMember(d => d.Price, opt => opt.MapFrom(o => Convert.ToDecimal(o.Price, new CultureInfo("es-CO"))))
            .ForMember(d => d.IsActive, opt => opt.MapFrom(o => o.IsActive == 1 ? true : false)); ;
        }
    }
}
