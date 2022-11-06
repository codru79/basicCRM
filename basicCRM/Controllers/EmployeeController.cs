﻿using basicCRM.Data;
using basicCRM.Models;
using basicCRM.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace basicCRM.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;

        public List<String> lroles = new List<String>() { "Sales", "AccountManager", "HeadOfSales" };
        public List<String> ldepartments = new List<String>() { "SalesEast", "SalesNorth", "SalesWest", "SalesSouth" };

        public EmployeeController(ApplicationDbContext dbcontext)
        {
            _employeeRepository = new EmployeeRepository(dbcontext);
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var list = _employeeRepository.GetAllEmployees();
            return View(list);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = new EmployeeModel();
            return View("DetailsEmployee",model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.roles = lroles;
            ViewBag.departments = ldepartments;
            return View("CreateEmployee");
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new EmployeeModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                { 
                _employeeRepository.InsertEmployee(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateEmployee");
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.roles = lroles;
            ViewBag.departments = ldepartments;
            var model = _employeeRepository.GetEmployeeById(id);
            return View("EditEmployee",model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new EmployeeModel();
                var task= TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _employeeRepository.UpdateEmployee(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditEmployee");
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _employeeRepository.GetEmployeeById(id);
            return View("DeleteEmployee",model);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
              _employeeRepository.DeleteEmployee(id);
              return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete",id);
            }
        }
    }
}
