using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagement.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly IEmployeeService _employeeService;

        private readonly ITimeSheetService _timeSheetService;

        public TimeSheetController(IEmployeeService employeeService, ITimeSheetService timeSheetService)
        {
            _employeeService = employeeService;
            _timeSheetService = timeSheetService;
        }

        public ActionResult Store()
        {
            ViewBag.Employees = _employeeService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Store(TimeSheetViewModel timeSheetViewModel)
        {
            var employee = _employeeService.GetById(timeSheetViewModel.EmployeeId);
            var timeSheet = new TimeSheet()
            {
                Desc = timeSheetViewModel.Desc,
                Date = timeSheetViewModel.Date,
                HoursOfWork = timeSheetViewModel.HoursOfWork,
                Employee = employee,
            };
            if (ModelState.IsValid)
            {
                var success = _timeSheetService.Add(timeSheet);
                if (success) return RedirectToAction("Details", new { id = employee.Id });
                ViewBag.message = "There's error during adding Time Sheet";
                return View();
            }
            ViewBag.message = "Insert Failed !";
            return View();
        }

        public ActionResult Edit(int id)
        {

            var timeSheet = _timeSheetService.GetById(id);
            var timeSheetViewModel = new TimeSheetViewModel()
            {
                Id = timeSheet.Id,
                Desc = timeSheet.Desc,
                Date = timeSheet.Date,
                HoursOfWork = timeSheet.HoursOfWork,
                EmployeeId = timeSheet.Employee.Id
            };
            ViewBag.Employees = _employeeService.GetAll();
            return View(timeSheetViewModel);
        }

        [HttpPost]
        public ActionResult Edit(TimeSheetViewModel timeSheetViewModel)
        {
            var timeSheet = _timeSheetService.GetById(timeSheetViewModel.Id);
            var employee = _employeeService.GetById(timeSheetViewModel.EmployeeId);
            timeSheet.Date = timeSheetViewModel.Date;
            timeSheet.Desc = timeSheetViewModel.Desc;
            timeSheet.Employee = employee;
            timeSheet.HoursOfWork = timeSheetViewModel.HoursOfWork;
            if (ModelState.IsValid)
            {
                _timeSheetService.Update(timeSheet);
                return RedirectToAction("Details", new { id = employee.Id });
            }
            ViewBag.message = "Edit Failed !";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var timeSheet = _timeSheetService.GetById(id);
            var employeeId = _employeeService.GetById(timeSheet.Employee.Id).Id;
            _timeSheetService.Delete(id);
            return RedirectToAction("Details", new { id = employeeId });
        }

        public ActionResult Details(int id)
        {
            var timeSheets = _timeSheetService.GetAllTimeSheetsByEmployeeId(id);
            return View(timeSheets);
        }
        
    }
}
