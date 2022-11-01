using System;
using System.Collections.Generic;

namespace basicCRM.Models.DBObjects
{
    public partial class Offer
    {
        public Guid Idoffer { get; set; }
        public Guid Idopportunity { get; set; }
        public Guid Idowner { get; set; }
        public string OfferType { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ValueMwh { get; set; }

        public virtual Opportunity IdopportunityNavigation { get; set; } = null!;
        public virtual Employee IdownerNavigation { get; set; } = null!;
    }
}
