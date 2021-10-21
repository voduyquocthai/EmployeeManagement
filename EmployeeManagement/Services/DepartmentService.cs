using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
        }

        public IList<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Boolean Add(Department department)
        {
            var identity = _departmentRepository.SearchByName(department.Name);

            if (identity != 0)
            {
                return false;
            }
            department.Created = DateTime.Now;
            department.Modified = DateTime.Now;
            _departmentRepository.Insert(department);
            return true;
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public void Update(Department department)
        {
            var existDepartment = _departmentRepository.GetById(department.Id);
            existDepartment.Name = department.Name;
            existDepartment.ParentId = department.ParentId;
            existDepartment.Desc = department.Desc;
            existDepartment.ParentId = department.ParentId;
            existDepartment.Modified = DateTime.Now;
        }

        public void Delete(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department != null)
            {
                _departmentRepository.Delete(department);
            }
        }

        public List<DepartmentViewModel> GetTopThreeLargestDepartments()
        {
            var departments = _departmentRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var list =
                from d in departments
                join e in employees on d.Id equals e.Department.Id
                group e by e.Department.Id
                into g
                select new DepartmentViewModel
                {
                    Id = g.First().Department.Id,
                    Name = g.First().Department.Name,
                    Desc = g.First().Department.Desc,
                    NumberOfEmployees = g.Count()
                };
            var result = list.OrderByDescending(i => i.NumberOfEmployees).ToList().GetRange(0, 3);
            return result;
        }
    }
}

