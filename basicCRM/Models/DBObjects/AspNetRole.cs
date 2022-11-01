﻿using System;
using System.Collections.Generic;

namespace basicCRM.Models.DBObjects
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaim>();
            Employees = new HashSet<Employee>();
            Users = new HashSet<AspNetUser>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; }
    }
}
