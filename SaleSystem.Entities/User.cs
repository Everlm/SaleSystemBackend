using System;
using System.Collections.Generic;

namespace SaleSystem.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Role? Role { get; set; }
    }
}
