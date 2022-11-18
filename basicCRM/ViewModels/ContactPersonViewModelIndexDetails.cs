using basicCRM.Models;
using basicCRM.Repository;

namespace basicCRM.ViewModels
{
    public class ContactPersonViewModelIndexDetails
    {
        public Guid IdcontactPerson { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public Guid Idcustomer { get; set; }

        public string Customer { get; set; }

        public ContactPersonViewModelIndexDetails(ContactPersonModel model,CustomerRepository repository)
        {
            this.IdcontactPerson = model.IdcontactPerson;
            this.Name = model.Name;
            this.Email = model.Email;
            this.Phone = model.Phone;
            this.Idcustomer=model.Idcustomer;
            var customer = repository.GetCustomerById(model.Idcustomer);
            this.Customer = customer.Name;

        }
    }
}
