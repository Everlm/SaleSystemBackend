using System;
using System.Collections.Generic;

namespace SaleSystem.Entities
{
    public partial class Role
    {
        public Role()
        {
            MenuRoles = new HashSet<MenuRole>();
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string? Name { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<MenuRole> MenuRoles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
