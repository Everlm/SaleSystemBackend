namespace SaleSystem.DTO.Dtos
{
    public class ReportDto
    {
        public string? DocumentNumber { get; set; }
        public string? PaymentType { get; set; }
        public string? CreationDate { get; set; }
        public string? TotalSale { get; set; }
        public string? Product { get; set; }
        public int? Quantity { get; set; }
        public string? Price { get; set; }
        public string? Total { get; set; }
    }
}
