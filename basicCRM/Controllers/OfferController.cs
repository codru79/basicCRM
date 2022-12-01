using basicCRM.Data;
using basicCRM.Repository;
using basicCRM.ViewModels;
using basicCRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace basicCRM.Controllers
{
    [Authorize(Roles = "HeadOfSales,Sales,AccountManager")]
    public class OfferController : Controller
    {
        private OfferRepository _offerRepository;
        private EmployeeRepository _employeeRepository;
        private OpportunityRepository _opportunityRepository;

        public List<String> loffertypes = new List<String>() { "Binding", "Indicative"};

        public OfferController(ApplicationDbContext _DBContext)
        { 
            _offerRepository = new OfferRepository(_DBContext);
            _employeeRepository = new EmployeeRepository(_DBContext);
            _opportunityRepository=new OpportunityRepository(_DBContext);
        }
        // GET: OfferController
        public ActionResult Index(string searchString, int page)
        {
            var list=_offerRepository.GetAllOffers();
            int pageSize = 2;
            if (page < 1)
            {
                page = 1;
            }

            int recordsSkip = (page - 1) * pageSize;
            int recordsCount = list.Count();
            if (!String.IsNullOrEmpty(searchString))
            {
                list = _offerRepository.GetAllOffersFilteredBy(searchString);
            }
            var viewmodellist = new List<OfferViewModelIndexDetails>();
            foreach (var offer in list)
            {
                viewmodellist.Add(new OfferViewModelIndexDetails(offer, _opportunityRepository, _employeeRepository));
            }
            var pager = new Pager(recordsCount, page, pageSize);
            var data = viewmodellist.Skip(recordsSkip).Take(pager.PageSize);

            this.ViewBag.Pager = pager;
            return View(data);
        }

        // GET: OfferController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _offerRepository.GetOfferById(id);
            var viewmodel = new OfferViewModelIndexDetails(model, _opportunityRepository, _employeeRepository);
            return View("DetailsOffer",viewmodel);
        }

        // GET: OfferController/Create
        public ActionResult Create()
        {
            ViewBag.offertypes=loffertypes;
            var viewmodel = new OfferViewModelCreateEdit(new OfferModel(), _opportunityRepository, _employeeRepository);
            return View("CreateOffer",viewmodel);
        }

        // POST: OfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new OfferModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _offerRepository.InsertOffer(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateOffer");
            }
        }

        // GET: OfferController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.offertypes = loffertypes;
            var model = _offerRepository.GetOfferById(id);
            var viewmodel = new OfferViewModelCreateEdit(model, _opportunityRepository, _employeeRepository); 
            return View("EditOffer",viewmodel);
        }

        // POST: OfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new OfferModel();
                var task = TryUpdateModelAsync(model);
                //model.Idoffer=id;
                if (task.Result)
                {
                    _offerRepository.UpdateOffer(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditOffer");
            }
        }

        // GET: OfferController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _offerRepository.GetOfferById(id);
            var viewmodel= new OfferViewModelCreateEdit(model, _opportunityRepository, _employeeRepository);
            return View("DeleteOffer",viewmodel);
        }

        // POST: OfferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _offerRepository.DeleteOffer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete",id);
            }
        }
    }
}
