using System;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            return View(employees);
        }

        public ActionResult Store()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Store(EmployeeViewModel employeeVM)
        {
            var department = _departmentService.GetById(employeeVM.DepartmentId);
            var employee = new Employee()
            {
                Name = employeeVM.Name,
                Desc = employeeVM.Desc,
                DateOfBirth = employeeVM.DateOfBirth,
                YearsOfExperience = employeeVM.YearsOfExperience,
                PhoneNumber = employeeVM.PhoneNumber,
                Department = department,
            };
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
