using System;
using System.Collections.Generic;

namespace basicCRM.Models.DBObjects
{
    public partial class ContactPerson
    {
        public Guid IdcontactPerson { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public Guid Idcustomer { get; set; }

        public virtual Customer IdcustomerNavigation { get; set; } = null!;
    }
}
