using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using CsvHelper;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.ApiControllers
{
    [Route("api/import")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;

        public ValuesController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, ITimeSheetRepository timeSheetRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _timeSheetRepository = timeSheetRepository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public String Get()
        {
            var department1 = new Department {Name = "DE1", Created = DateTime.Now, Modified = DateTime.Now, ParentId = 99, Desc = "80 Dich Vong Hau"};
            var department2 = new Department {Name = "DE2", Created = DateTime.Now, Modified = DateTime.Now, ParentId = 99, Desc = "TC Building"};
            var department3 = new Department {Name = "DE3", Created = DateTime.Now, Modified = DateTime.Now, ParentId = 99, Desc = "Toa Thanh Cong"};
            var department4 = new Department {Name = "DE4", Created = DateTime.Now, Modified = DateTime.Now, ParentId = 99, Desc = "CMC Tower"};
            var department5 = new Department {Name = "DE5", Created = DateTime.Now, Modified = DateTime.Now, ParentId = 99, Desc = "CMC Da Nang"};
            _departmentRepository.Insert(department1);
            _departmentRepository.Insert(department2);
            _departmentRepository.Insert(department3);
            _departmentRepository.Insert(department4);
            _departmentRepository.Insert(department5);
            var employee1 = new Employee{Name = "Thai", Desc = ".NET Dev", DateOfBirth = "06/11/1993", YearsOfExperience = 1, PhoneNumber = "123456", Department = department1, Created = DateTime.Now, Modified = DateTime.Now, };
            var employee2 = new Employee{Name = "Binh", Desc = "Java Dev", DateOfBirth = "13/11/2000", YearsOfExperience = 4, PhoneNumber = "958784", Department = department2, Created = DateTime.Now, Modified = DateTime.Now, };
            var employee3 = new Employee{Name = "Minh", Desc = "Tester", DateOfBirth = "09/11/1997", YearsOfExperience = 6, PhoneNumber = "363832", Department = department3, Created = DateTime.Now, Modified = DateTime.Now, };
            var employee4 = new Employee{Name = "Tu", Desc = "QA", DateOfBirth = "23/11/1988", YearsOfExperience = 7, PhoneNumber = "1093637", Department = department1, Created = DateTime.Now, Modified = DateTime.Now, };
            var employee5 = new Employee{Name = "Truong", Desc = "BA", DateOfBirth = "17/11/1995", YearsOfExperience = 8, PhoneNumber = "3728209", Department = department2, Created = DateTime.Now, Modified = DateTime.Now, };
            _employeeRepository.Insert(employee1);
            _employeeRepository.Insert(employee2);
            _employeeRepository.Insert(employee3);
            _employeeRepository.Insert(employee4);
            _employeeRepository.Insert(employee5);
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 21), Desc = "Pattern Project", HoursOfWork = 7, Employee = employee1}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 20), Desc = "Pattern Project", HoursOfWork = 3, Employee = employee1}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 19), Desc = "Pattern Project", HoursOfWork = 5, Employee = employee1}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 18), Desc = "Pattern Project", HoursOfWork = 8, Employee = employee3}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 17), Desc = "Pattern Project", HoursOfWork = 4, Employee = employee3}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 21), Desc = "Pattern Project", HoursOfWork = 8, Employee = employee3}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 19), Desc = "Pattern Project", HoursOfWork = 6, Employee = employee5}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 18), Desc = "Pattern Project", HoursOfWork = 12, Employee = employee5}); 
            _timeSheetRepository.Insert(new TimeSheet{Date = new DateTime(2021, 10, 17), Desc = "Pattern Project", HoursOfWork = 1, Employee = employee5}); 
            return "Import Successfully";
        }

      
    }
}
