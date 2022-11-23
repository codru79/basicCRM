using basicCRM.Models;
using basicCRM.Repository;

namespace basicCRM.ViewModels
{
    public class ContactPersonViewModelCreateEdit:ContactPersonViewModelIndexDetails
    {
        public List<CustomerModel> Customers { get; set; }
        public ContactPersonViewModelCreateEdit(ContactPersonModel model, CustomerRepository repository) : base(model, repository)
        { 
        
            this.Customers= repository.GetAllCustomers();
        }
    }
}
