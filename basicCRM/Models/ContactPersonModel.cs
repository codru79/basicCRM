namespace basicCRM.Models
{
    public class ContactPersonModel
    {
        public Guid IdcontactPerson { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public Guid Idcustomer { get; set; }
    }
}
