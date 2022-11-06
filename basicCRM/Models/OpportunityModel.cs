using System.ComponentModel.DataAnnotations;

namespace basicCRM.Models
{
    public class OpportunityModel
    {

        public Guid Idopportunity { get; set; }
        public string Name { get; set; } = null!;
        public Guid Idcustomer { get; set; }
        public string? CommodityType { get; set; }
        public Guid Idemployee { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? ValidFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? ValidTo { get; set; }
        public string? Status { get; set; }
    }
}
