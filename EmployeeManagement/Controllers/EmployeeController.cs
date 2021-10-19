using System;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository departmentRepository)
        {
            _employeeRepository = departmentRepository;
        }
        public IActionResult Index(int departmentId)
        {

            var employees = _employeeRepository.GetAll();
            ViewBag.list = employees;
            return View();
        }

        [HttpPost]
        public ActionResult Store(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepository.SearchByName(employee);

                if (count != 0)
                {
                    ViewBag.message = "This department already existing";
                    return View();
                }
                employee.Created = DateTime.Now;
                employee.Modified = DateTime.Now;
                _employeeRepository.Insert(employee);
                return RedirectToAction("Index");
            }

            ViewBag.message = "Insert Failed !";
            return View();
        }


    }
}
