using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        IList<Employee> GetAll();
        bool Add(Employee employee);
        Employee GetById(int id);
        void Update(Employee employee);
        void Delete(int id);
        List<EmployeeViewModel> GetTopThreeHardWorkingEmployees();
        List<Employee> GetAllEmployeesMoreThan5YearsExperience();
    }
}