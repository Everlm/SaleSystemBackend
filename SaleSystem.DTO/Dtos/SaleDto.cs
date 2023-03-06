namespace SaleSystem.DTO.Dtos
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public string? DocumentNumeber { get; set; }
        public string? PaymentType { get; set; }
        public string? Total { get; set; }
        public string? CreationDate { get; set; }

        public virtual ICollection<SaleDetailDto> SaleDetails { get; set; }
    }
}
