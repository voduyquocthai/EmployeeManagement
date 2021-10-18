using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;

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

            _departmentRepository.Insert(new Department()
            {
                Id = 12343,
                Name = "real name",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Name = "Employee 1"
                    }, new Employee()
                    {
                        Name = "Employee 1"
                    }, new Employee()
                    {
                        Name = "Employee 1"
                    }, new Employee()
                    {
                        Name = "Employee 1"
                    }, new Employee()
                    {
                        Name = "Employee 1"
                    }, new Employee()
                    {
                        Name = "Employee 1"
                    }, new Employee()
                    {
                        Name = "Employee 1"
                    }, new Employee()
                    {
                        Name = "Employee 1"
                    },
                }
            });

            var item = _departmentRepository.GetById(12343);


            return View(item);
        }
    }
}
