using System;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            return View(employees);
        }

        public ActionResult Store()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Boolean success = _employeeService.Add(employee);
                if (!success)
                {
                    ViewBag.message = "This department already existing";
                    return View();
                }
                return RedirectToAction("Index");
            }
            ViewBag.message = "Insert Failed !";
            return View();
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            return View(employee);
        }

        [HttpPost]
        // [MyCustomFilter]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            ViewBag.message = "Edit Failed !";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
