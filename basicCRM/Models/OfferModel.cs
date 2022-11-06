using System.ComponentModel.DataAnnotations;

namespace basicCRM.Models
{
    public class OfferModel
    {
        public Guid Idoffer { get; set; }
        public Guid Idopportunity { get; set; }
        public Guid Idowner { get; set; }
        public string OfferType { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int ValueMwh { get; set; }
    }
}
