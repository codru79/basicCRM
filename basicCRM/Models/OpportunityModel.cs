namespace basicCRM.Models
{
    public class OpportunityModel
    {
        public Guid Idopportunity { get; set; }
        public string Name { get; set; } = null!;
        public Guid Idcustomer { get; set; }
        public string CommodityType { get; set; } = null!;
        public Guid Idowner { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Status { get; set; } = null!;
    }
}
