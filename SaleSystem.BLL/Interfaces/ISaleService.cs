using SaleSystem.DTO.Dtos;

namespace SaleSystem.BLL.Interfaces
{
    public interface ISaleService
    {
        Task<SaleDto> Register(SaleDto sale);
        Task<List<SaleDto>> GetHistory(string findBy, string saleNumber, string startDate, string endDate);
        Task<List<ReportDto>> Report(string startDate, string endDate);
    }
}
