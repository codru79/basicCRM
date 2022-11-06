using basicCRM.Repository;
using basicCRM.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using basicCRM.Models;

namespace basicCRM.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository _customerRepository;

        public CustomerController(ApplicationDbContext dbcontext)
        { 
        _customerRepository = new CustomerRepository(dbcontext);
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var list = _customerRepository.GetAllCustomers();
            return View(list);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _customerRepository.GetCustomerById(id);
            return View("DetailsCustomer",model);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new CustomerModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _customerRepository.InsertCustomer(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateCustomer");
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model =_customerRepository.GetCustomerById(id);
            return View("EditCustomer",model);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new CustomerModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _customerRepository.UpdateCustomer(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditCustomer");
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _customerRepository.GetCustomerById(id);
            return View("DeleteCustomer",model);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {

                _customerRepository.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete",id);
            }
        }
    }
}
