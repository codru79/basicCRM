using basicCRM.Data;
using basicCRM.Repository;
using basicCRM.ViewModels;
using basicCRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basicCRM.Controllers
{
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
        public ActionResult Index()
        {
            var list=_offerRepository.GetAllOffers();
            var viewmodellist = new List<OfferViewModel>();
            foreach (var offer in list)
            {
                viewmodellist.Add(new OfferViewModel(offer, _opportunityRepository, _employeeRepository));
            }
            return View(viewmodellist);
        }

        // GET: OfferController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _offerRepository.GetOfferById(id);
            var viewmodel = new OfferViewModel(model, _opportunityRepository, _employeeRepository);
            return View("DetailsOffer",viewmodel);
        }

        // GET: OfferController/Create
        public ActionResult Create()
        {
            ViewBag.offertypes=loffertypes;
            var viewmodel = new OfferViewModelExtended(new OfferModel(), _opportunityRepository, _employeeRepository);
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
            var viewmodel = new OfferViewModelExtended(model, _opportunityRepository, _employeeRepository); 
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
                model.Idoffer=id;
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
            var viewmodel= new OfferViewModelExtended(model, _opportunityRepository, _employeeRepository);
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
