using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;
using System.Globalization;

namespace SaleSystem.Utilities.Mappers
{
    public class SaleDetailsMappingsProfile : Profile
    {
        public SaleDetailsMappingsProfile()
        {
            CreateMap<SaleDetail, SaleDetailDto>()
             .ForMember(d => d.ProductDescription, opt => opt.MapFrom(o => o.Product.Name))
             .ForMember(d => d.Price, opt => opt.MapFrom(o => Convert.ToString(o.Price.Value, new CultureInfo("es-CO"))))
             .ForMember(d => d.Total, opt => opt.MapFrom(o => Convert.ToString(o.Total.Value, new CultureInfo("es-CO"))));

            CreateMap<SaleDetailDto, SaleDetail>()
            .ForMember(d => d.Price, opt => opt.MapFrom(o => Convert.ToDecimal(o.Price, new CultureInfo("es-CO"))))
            .ForMember(d => d.Total, opt => opt.MapFrom(o => Convert.ToDecimal(o.Total, new CultureInfo("es-CO"))));
        }
    }
}
