using System;
using System.Collections.Generic;

namespace SaleSystem.Entities.Entities
{
    public partial class Product
    {
        public Product()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
