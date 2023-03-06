namespace SaleSystem.DTO.Dtos
{
    public class SaleDetailDto
    {
        public int? ProductId { get; set; }
        public string? ProductDescription { get; set; }
        public int? Quantity { get; set; }
        public string? Price { get; set; }
        public string? Total { get; set; }
    }
}
