using basicCRM.Repository;
using basicCRM.Models;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace basicCRM.ViewModels
{
    public class OpportunityViewModelIndexDetails
    {
        public Guid Idopportunity { get; set; }
        public string Name { get; set; } = null!;
        public Guid Idcustomer { get; set; }

        public string? CommodityType { get; set; } = null!;
        public Guid Idemployee { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? ValidFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? ValidTo { get; set; }

        public string? Status { get; set; } = null!;

        public string Owner { get; set; }
        public string Customer { get; set; }

        public OpportunityViewModelIndexDetails(OpportunityModel model, CustomerRepository crepository, EmployeeRepository erepository)
        { 
            this.Idopportunity = model.Idopportunity;
            this.Name = model.Name;
            this.Idcustomer = model.Idcustomer;
            this.CommodityType = model.CommodityType;
            this.Idemployee = model.Idemployee;
            this.ValidFrom= model.ValidFrom;
            this.ValidTo= model.ValidTo;
            this.Status = model.Status;
            var employee = erepository.GetEmployeeById(model.Idemployee);
            this.Owner = employee.Name;
            var customer = crepository.GetCustomerById(model.Idcustomer);
            this.Customer = customer.Name;
        }
    }
}
