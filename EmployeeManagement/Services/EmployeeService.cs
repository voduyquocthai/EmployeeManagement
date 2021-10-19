using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService : IGeneralService<Employee>
    {
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IList<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public bool Add(Employee employee)
        {
            var identity = _employeeRepository.SearchByName(employee);

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
    }
}
