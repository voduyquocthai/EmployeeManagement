using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ITimeSheetRepository timeSheetRepository)
        {
            _employeeRepository = employeeRepository;
            _timeSheetRepository = timeSheetRepository;
        }
        public IList<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public bool Add(Employee employee)
        {
            var identity = _employeeRepository.SearchByName(employee.Name);

            if (identity != 0)
            {
                return false;
            }
            employee.Created = DateTime.Now;
            employee.Modified = DateTime.Now;
            _employeeRepository.Insert(employee);
            return true;
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void Update(Employee employee)
        {
            var existEmployee = _employeeRepository.GetById(employee.Id);
            existEmployee.Name = employee.Name;
            existEmployee.Desc = employee.Desc;
            existEmployee.DateOfBirth = employee.DateOfBirth;
            existEmployee.YearsOfExperience = employee.YearsOfExperience;
            existEmployee.PhoneNumber = employee.PhoneNumber;
            existEmployee.Department = employee.Department;
            existEmployee.Modified = DateTime.Now;
        }

        public void Delete(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
            }
        }

        public List<EmployeeViewModel> GetTopThreeHardWorkingEmployees()
        {
            var employees = _employeeRepository.GetAll();
            var timeSheets = _timeSheetRepository.GetAll();
            var list =
                from e in employees
                join t in timeSheets on e.Id equals t.Employee.Id
                where t.Date.Month == DateTime.Now.Month
                group t by t.Employee.Id into g
                select new EmployeeViewModel
                {
                    Id = g.First().Employee.Id,
                    Name = g.First().Employee.Name,
                    TotalHoursOfWork = g.Sum(t => t.HoursOfWork),
                    DepartmentName = g.First().Employee.Department.Name,

                };
            var result = list.OrderByDescending(i => i.TotalHoursOfWork).ToList().GetRange(0, 3);
            return result;
        }

        public List<Employee> GetAllEmployeesMoreThan5YearsExperience()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployeesFrom5YearsExperience()
        {
            var employees = _employeeRepository.GetAll();
            var list = employees.Where(i => i.YearsOfExperience >= 5).ToList();
            return list;
        }
    }
}
