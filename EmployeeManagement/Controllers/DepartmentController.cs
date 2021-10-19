using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {

            var departments = _departmentService.GetAll();
            ViewBag.list = departments;
            return View();
        }

        public ActionResult Store()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(Department department)
        {
            if (ModelState.IsValid)
            {
                Boolean success = _departmentService.Add(department);
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
            var department = _departmentService.GetById(id);
            return View(department);
        }

        [HttpPost]
        // [MyCustomFilter]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Update(department);
                return RedirectToAction("Index");
            }

            ViewBag.message = "Edit Failed !";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
