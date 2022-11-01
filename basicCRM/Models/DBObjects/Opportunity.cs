using System;
using System.Collections.Generic;

namespace basicCRM.Models.DBObjects
{
    public partial class Opportunity
    {
        public Opportunity()
        {
            Offers = new HashSet<Offer>();
        }

        public Guid Idopportunity { get; set; }
        public string Name { get; set; } = null!;
        public Guid Idcustomer { get; set; }
        public string CommodityType { get; set; } = null!;
        public Guid Idowner { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Customer IdcustomerNavigation { get; set; } = null!;
        public virtual Employee IdownerNavigation { get; set; } = null!;
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
