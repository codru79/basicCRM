using basicCRM.Models;
using basicCRM.Repository;
using System.ComponentModel.DataAnnotations;

namespace basicCRM.ViewModels
{
    public class OfferViewModel
    {
        public Guid Idoffer { get; set; }
        public Guid Idopportunity { get; set; }
        public Guid Idowner { get; set; }
        public string OfferType { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int ValueMwh { get; set; }

        public string Owner { get; set; }
        public string Opportunity { get; set; }

        public OfferViewModel(OfferModel model, OpportunityRepository orepository, EmployeeRepository erepository)
        { 
        
            this.Idoffer=model.Idoffer;
            this.Idopportunity=model.Idopportunity;
            this.Idowner=model.Idowner;
            this.OfferType=model.OfferType;
            this.CreatedDate=model.CreatedDate;
            this.ExpireDate=model.ExpireDate;
            this.ValueMwh=model.ValueMwh;
            var employee = erepository.GetEmployeeById(model.Idowner);
            this.Owner = employee.Name;
            var opportunity = orepository.GetOpportunityByID(model.Idopportunity);
            this.Opportunity= opportunity.Name;
        }
    }
}
