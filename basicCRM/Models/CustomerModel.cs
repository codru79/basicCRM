namespace basicCRM.Models
{
    public class CustomerModel
    {
        public Guid Idcustomer { get; set; }
        public string Name { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public DateTime AddedDate { get; set; }
    }
}
