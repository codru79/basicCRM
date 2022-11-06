using basicCRM.Models;
using basicCRM.Repository;

namespace basicCRM.ViewModels
{
    public class OpportunityViewModelExtended : OpportunityViewModel
    {
        public List<EmployeeModel> Employees { get; set; }
        public List<CustomerModel> Customers { get; set; }


        public OpportunityViewModelExtended(OpportunityModel model, CustomerRepository crepository, EmployeeRepository erepository) : base(model, crepository, erepository)
        {

            this.Customers = crepository.GetAllCustomers();
            this.Employees = erepository.GetAllEmployees();

        }
    }
}
