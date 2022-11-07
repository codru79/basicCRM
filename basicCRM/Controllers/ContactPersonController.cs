using basicCRM.Data;
using basicCRM.Repository;
using basicCRM.ViewModels;
using basicCRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basicCRM.Controllers
{
    public class ContactPersonController : Controller
    {
        private ContactPersonRepository _contactpersonRepository;
        private CustomerRepository _customerRepository;

        public ContactPersonController(ApplicationDbContext dbcontext)
        {
            _contactpersonRepository = new ContactPersonRepository(dbcontext);
            _customerRepository = new CustomerRepository(dbcontext);    
        }
        // GET: ContactPersonController
        public ActionResult Index()
        {
            var list = _contactpersonRepository.GetAllContactPersons();
            var viewmodellist = new List<ContactPersonViewModel>();
            foreach (var contactperson in list)
            {
                viewmodellist.Add(new ContactPersonViewModel(contactperson, _customerRepository));
            }
            return View(viewmodellist);
        }

        // GET: ContactPersonController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _contactpersonRepository.GetContactPersonById(id);
            var viewmodel = new ContactPersonViewModel(model, _customerRepository);
            return View("DetailsContactPerson",viewmodel);
        }

        // GET: ContactPersonController/Create
        public ActionResult Create()
        {
            var viewmodel = new ContactPersonViewModelExtended(new ContactPersonModel(), _customerRepository);
            return View("CreateContactPerson",viewmodel);
        }

        // POST: ContactPersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new ContactPersonModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _contactpersonRepository.InsertContactPerson(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateContactPerson");
            }
        }

        // GET: ContactPersonController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _contactpersonRepository.GetContactPersonById(id);
            var viewmodel = new ContactPersonViewModelExtended(model, _customerRepository);
            return View("EditContactPerson",viewmodel);
        }

        // POST: ContactPersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ContactPersonModel();
                var task = TryUpdateModelAsync(model);
                model.IdcontactPerson=id;
                if (task.Result)
                { 
                _contactpersonRepository.UpdateContactPerson(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditContactPerson");
            }
        }

        // GET: ContactPersonController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model= _contactpersonRepository.GetContactPersonById(id);
            var viewmodel = new ContactPersonViewModel(model, _customerRepository);
            return View("DeleteContactPerson",viewmodel);
        }

        // POST: ContactPersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _contactpersonRepository.DeleteContactPerson(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete",id);
            }
        }
    }
}
