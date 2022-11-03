using basicCRM.Models;
using basicCRM.Repository;

namespace basicCRM.ViewModels
{ 
    public class OpportunityViewModelCreate : OpportunityViewModel
    {
        public List<EmployeeModel> Employees { get; set; }
        public List<CustomerModel> Customers { get; set; }


        public OpportunityViewModelCreate(OpportunityModel model, CustomerRepository crepository, EmployeeRepository erepository) :base(model, crepository, erepository)
        {
            this.Employees = erepository.GetAllEmployees();
            this.Customers = crepository.GetAllCustomers();

        }
    }
}
