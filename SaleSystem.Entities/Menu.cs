﻿using System;
using System.Collections.Generic;

namespace SaleSystem.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            MenuRoles = new HashSet<MenuRole>();
        }

        public int MenuId { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<MenuRole> MenuRoles { get; set; }
    }
}
