using System;
using System.Collections.Generic;

namespace basicCRM.Models.DBObjects
{
    public partial class Employee
    {
        public Employee()
        {
            Offers = new HashSet<Offer>();
            Opportunities = new HashSet<Opportunity>();
        }

        public Guid Idemployee { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string? Role { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}
