using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using basicCRM.Repository;
using basicCRM.Data;
using basicCRM.Models;
using basicCRM.ViewModels;

namespace basicCRM.Controllers
{
    public class OpportunityController : Controller
    {

        private OpportunityRepository _opportunityRepository;
        private EmployeeRepository _employeeRepository;
        private CustomerRepository _customerRepository;

        public OpportunityController(ApplicationDbContext _DBContext)
        { 
            _opportunityRepository= new OpportunityRepository(_DBContext);
            _employeeRepository= new EmployeeRepository(_DBContext);
            _customerRepository= new CustomerRepository(_DBContext);    
        }


        // GET: OpportunityController
        public ActionResult Index()
        {
            var list = _opportunityRepository.GetAllOpportunities();
            var viewmodellist = new List<OpportunityViewModel>();
            foreach (var opportunity in list)
            {
                viewmodellist.Add(new OpportunityViewModel(opportunity, _customerRepository,_employeeRepository));
            }

            return View(viewmodellist);
        }

        // GET: OpportunityController/Details/5
        public ActionResult Details(Guid id)
        {
            return View("DetailsOpportunity");
        }

        // GET: OpportunityController/Create
        public ActionResult Create()
        {
            var viewmodel = new OpportunityViewModelCreate(new OpportunityModel(),_customerRepository, _employeeRepository);
            return View("CreateOpportunity",viewmodel);
        }

        // POST: OpportunityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new OpportunityModel();
                var task = TryUpdateModelAsync(model);
                if(task.Result)
                {
                    _opportunityRepository.InsertOpportunity(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateOpportunity");
            }
        }

        // GET: OpportunityController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _opportunityRepository.GetOpportunityByID(id);
            return View("EditOpportunity",model);
        }

        // POST: OpportunityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new OpportunityModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _opportunityRepository.UpdateOpportunity(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditOpportunity");
            }
        }

        // GET: OpportunityController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model= _opportunityRepository.GetOpportunityByID(id);
            return View("DeleteOpportunity",model);
        }

        // POST: OpportunityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _opportunityRepository.DeleteOpportunity(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
