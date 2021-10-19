using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Services
{

    public interface IDepartmentService : IGeneralService<Department>
    {
    }

    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IList<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Boolean Add(Department department)
        {
            var identity = _departmentRepository.SearchByName(department);

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
    }
}

