using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basicCRM.Controllers
{
    public class OpportunityController : Controller
    {
        // GET: OpportunityController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OpportunityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OpportunityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpportunityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpportunityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OpportunityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpportunityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OpportunityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
