using basicCRM.Models;
using basicCRM.Repository;

namespace basicCRM.ViewModels
{
    public class OfferViewModelCreateEdit:OfferViewModelIndexDetails
    {
        public List<OpportunityModel> Opportunities { get; set; }
        public List<EmployeeModel> Employees { get; set; }

        

        public OfferViewModelCreateEdit(OfferModel model, OpportunityRepository orepository, EmployeeRepository erepository) : base(model, orepository, erepository)
        { 
            this.Opportunities=orepository.GetAllOpportunities();
            this.Employees = erepository.GetAllEmployees();
        }
    }
}
