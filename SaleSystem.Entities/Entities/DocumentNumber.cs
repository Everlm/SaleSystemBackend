using System;
using System.Collections.Generic;

namespace SaleSystem.Entities.Entities
{
    public partial class DocumentNumber
    {
        public int DocumentNumberId { get; set; }
        public int LastNumber { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
