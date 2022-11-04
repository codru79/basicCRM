using basicCRM.Repository;
using basicCRM.Models;
using NuGet.Protocol.Core.Types;

namespace basicCRM.ViewModels
{
    public class OpportunityViewModel
    {
        public Guid Idopportunity { get; set; }
        public string Name { get; set; } = null!;
        public Guid Idcustomer { get; set; }

        public string? CommodityType { get; set; } = null!;
        public Guid Idowner { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public string? Status { get; set; } = null!;

        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }

        public OpportunityViewModel(OpportunityModel model, CustomerRepository crepository, EmployeeRepository erepository)
        { 
        this.Idopportunity = model.Idopportunity;
            this.Name = model.Name;
            this.Idcustomer = model.Idcustomer;
            this.CommodityType = model.CommodityType;
            this.Idowner=model.Idowner;
            this.ValidFrom= model.ValidFrom;
            this.ValidTo= model.ValidTo;
            this.Status = model.Status;
            var employee = erepository.GetEmployeeById(model.Idowner);
            this.EmployeeName = employee.Name;
            var customer = crepository.GetCustomerById(model.Idcustomer);
            this.CustomerName = customer.Name;
        }
    }
}
