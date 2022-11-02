namespace basicCRM.Models
{
    public class OfferModel
    {
        public Guid Idoffer { get; set; }
        public Guid Idopportunity { get; set; }
        public Guid Idowner { get; set; }
        public string OfferType { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ValueMwh { get; set; }
    }
}
