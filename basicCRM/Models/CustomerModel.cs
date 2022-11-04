using System.ComponentModel.DataAnnotations;

namespace basicCRM.Models
{
    public class CustomerModel
    {
        public Guid Idcustomer { get; set; }
        public string Name { get; set; } = null!;
        public string Adress { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
    }
}
