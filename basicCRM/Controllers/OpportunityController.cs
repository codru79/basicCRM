using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using basicCRM.Repository;
using basicCRM.Data;
using basicCRM.Models;
using basicCRM.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace basicCRM.Controllers
{
    [Authorize(Roles = "HeadOfSales,Sales,AccountManager")]
    public class OpportunityController : Controller
    {

        private OpportunityRepository _opportunityRepository;
        private EmployeeRepository _employeeRepository;
        private CustomerRepository _customerRepository;
        
        public List<String> lcommoditytype = new List<String>() { "Gas","Power","Gas&Power"};
        public List<String> lstatus = new List<String>() { "Won", "Lost", "Open" };

        public OpportunityController(ApplicationDbContext _DBContext)
        { 
            _opportunityRepository= new OpportunityRepository(_DBContext);
            _employeeRepository= new EmployeeRepository(_DBContext);
            _customerRepository= new CustomerRepository(_DBContext);    
        }


        // GET: OpportunityController
        public ActionResult Index(string searchString,int page)
        {
            var list = _opportunityRepository.GetAllOpportunities();
            int pageSize = 2;
            if (page < 1)
            {
                page = 1;
            }

            int recordsSkip = (page - 1) * pageSize;
            int recordsCount = list.Count();
            if (!String.IsNullOrEmpty(searchString))
            {
                list = _opportunityRepository.GetAllOpportunitiesFilteredBy(searchString);
            }
            var viewmodellist = new List<OpportunityViewModelIndexDetails>();
            foreach (var opportunity in list)
            {
                viewmodellist.Add(new OpportunityViewModelIndexDetails(opportunity, _customerRepository,_employeeRepository));
            }
            var pager = new Pager(recordsCount, page, pageSize);
            var data = viewmodellist.Skip(recordsSkip).Take(pager.PageSize);

            this.ViewBag.Pager = pager;
            return View(data);
        }

        // GET: OpportunityController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _opportunityRepository.GetOpportunityByID(id);
            var viewmodel = new OpportunityViewModelIndexDetails(model, _customerRepository, _employeeRepository);
            return View("DetailsOpportunity", viewmodel);
        }

        // GET: OpportunityController/Create
        public ActionResult Create()
        {

            ViewBag.commoditytypes = lcommoditytype;
            ViewBag.statuses = lstatus;
            var viewmodel = new OpportunityViewModelCreateEdit(new OpportunityModel(),_customerRepository, _employeeRepository);
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
            ViewBag.commoditytypes = lcommoditytype;
            ViewBag.statuses = lstatus;
            var model = _opportunityRepository.GetOpportunityByID(id);
            var viewmodel = new OpportunityViewModelCreateEdit(model, _customerRepository, _employeeRepository);  
            return View("EditOpportunity",viewmodel);
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
                model.Idopportunity=id;
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
        [Authorize(Roles = "HeadOfSales,AccountManager")]
        // GET: OpportunityController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model= _opportunityRepository.GetOpportunityByID(id);
            var viewmodel = new OpportunityViewModelIndexDetails(model, _customerRepository, _employeeRepository);
            return View("DeleteOpportunity",viewmodel);
        }

        [Authorize(Roles = "HeadOfSales,AccountManager")]
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
