using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository departmentRepository)
        {
            _employeeRepository = departmentRepository;
        }
        public IActionResult Index(int departmentId)
        {

            var employees = _employeeRepository.GetAll();
            ViewBag.list = employees;
            return View();
        }
    }
}
