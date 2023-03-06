using System;
using System.Collections.Generic;

namespace SaleSystem.Entities.Entities
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int SaleId { get; set; }
        public string? DocumentNumeber { get; set; }
        public string? PaymentType { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
