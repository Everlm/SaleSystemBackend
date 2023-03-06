namespace SaleSystem.DTO.Dtos
{
    public class DashBoardDto
    {
        public int? TotalSale { get; set; }
        public string? TotalIncome { get; set; }
        public List<WeekSaleDto> WeekSale { get; set; }
    }
}
