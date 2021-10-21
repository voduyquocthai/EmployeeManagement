using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public interface IDepartmentService
    {
        IList<Department> GetAll();
        bool Add(Department department);
        Department GetById(int id);
        void Update(Department department);
        void Delete(int id);
        List<DepartmentViewModel> GetTopThreeLargestDepartments();
    }
}