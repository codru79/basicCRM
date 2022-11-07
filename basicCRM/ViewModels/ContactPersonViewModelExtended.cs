using basicCRM.Models;
using basicCRM.Repository;

namespace basicCRM.ViewModels
{
    public class ContactPersonViewModelExtended:ContactPersonViewModel
    {
        public List<CustomerModel> Customers { get; set; }
        public ContactPersonViewModelExtended(ContactPersonModel model, CustomerRepository repository) : base(model, repository)
        { 
        
            this.Customers= repository.GetAllCustomers();
        }
    }
}
