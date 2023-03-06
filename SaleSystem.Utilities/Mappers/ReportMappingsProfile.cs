using AutoMapper;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;
using System.Globalization;

namespace SaleSystem.Utilities.Mappers
{
    public class ReportMappingsProfile : Profile
    {
        public ReportMappingsProfile()
        {
            CreateMap<SaleDetail, ReportDto>()
                  .ForMember(d => d.CreationDate, opt => opt.MapFrom(o => o.Sale.CreationDate.Value.ToString("dd/MM/yyyy")))
                  .ForMember(d => d.DocumentNumber, opt => opt.MapFrom(o => o.Sale.DocumentNumeber))
                  .ForMember(d => d.PaymentType, opt => opt.MapFrom(o => o.Sale.PaymentType))
                  .ForMember(d => d.TotalSale, opt => opt.MapFrom(o => Convert.ToString(o.Sale.Total.Value, new CultureInfo("es-CO"))))
                  .ForMember(d => d.Product, opt => opt.MapFrom(o => o.Product.Name))
                  .ForMember(d => d.Price, opt => opt.MapFrom(o => Convert.ToString(o.Price.Value, new CultureInfo("es-CO"))))
                  .ForMember(d => d.Total, opt => opt.MapFrom(o => Convert.ToString(o.Total.Value, new CultureInfo("es-CO"))));
        }
    }
}
