using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;
using System.Globalization;

namespace SaleSystem.Utilities.Mappers
{
    public class SaleMappingsProfile : Profile
    {
        public SaleMappingsProfile()
        {
            CreateMap<Sale, SaleDto>()
                 .ForMember(d => d.Total, opt => opt.MapFrom(o => Convert.ToString(o.Total.Value, new CultureInfo("es-CO"))))
                 .ForMember(d => d.CreationDate, opt => opt.MapFrom(o => o.CreationDate.Value.ToString("dd/MM/yyyy")));

            CreateMap<SaleDto, Sale>()
                 .ForMember(d => d.Total, opt => opt.MapFrom(o => Convert.ToDecimal(o.Total, new CultureInfo("es-CO"))));
        }
    }
}
