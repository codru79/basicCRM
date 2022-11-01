using System;
using System.Collections.Generic;

namespace basicCRM.Models.DBObjects
{
    public partial class Customer
    {
        public Customer()
        {
            ContactPeople = new HashSet<ContactPerson>();
            Opportunities = new HashSet<Opportunity>();
        }

        public Guid Idcustomer { get; set; }
        public string Name { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public DateTime AddedDate { get; set; }

        public virtual ICollection<ContactPerson> ContactPeople { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}
