using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public IActionResult Index()
        {

            var departments = _departmentRepository.GetAll();
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
                var count = _departmentRepository.SearchByName(department);
                    
                if (count != 0)
                {
                    ViewBag.message = "This department already existing";
                    return View();
                }
                department.Created = DateTime.Now;
                department.Modified = DateTime.Now;
                _departmentRepository.Insert(department);
                return RedirectToAction("Index");
            }

            ViewBag.message = "Insert Failed !";
            return View();
        }

        public ActionResult Edit(int id)
        {
            var department = _departmentRepository.GetById(id);
            return View(department);
        }

        [HttpPost]
        // [MyCustomFilter]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                var existDepartment = _departmentRepository.GetById(department.Id);
                existDepartment.Name = department.Name;
                existDepartment.Desc = department.Desc;
                existDepartment.ParentId = department.ParentId;
                existDepartment.Modified = DateTime.Now;
                return RedirectToAction("Index");
            }

            ViewBag.message = "Edit Failed !";
            return View();
        }

        [HttpGet]
        // [MyCustomFilter]
        public ActionResult Delete(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department != null)
            {
                _departmentRepository.Delete(department);
            }

            return RedirectToAction("Index");
        }
    }


    // public class MyCustomFilter: ActionFilterAttribute
    // {
    // }

}
