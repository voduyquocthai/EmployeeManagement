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
        public ActionResult Store(EmployeeViewModel employeeVm)
        {
            var department = _departmentService.GetById(employeeVm.DepartmentId);
            var employee = new Employee()
            {
                Name = employeeVm.Name,
                Desc = employeeVm.Desc,
                DateOfBirth = employeeVm.DateOfBirth,
                YearsOfExperience = employeeVm.YearsOfExperience,
                PhoneNumber = employeeVm.PhoneNumber,
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
            var employeeVm = new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Created = employee.Created,
                Modified = employee.Modified,
                Desc = employee.Desc,
                DateOfBirth = employee.DateOfBirth,
                YearsOfExperience = employee.YearsOfExperience,
                PhoneNumber = employee.PhoneNumber,
                DepartmentId = employee.Department.Id,
            };
            return View(employeeVm);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                // _employeeService.Update(employee);
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
