using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class DepartmentViewModel : ModelBase
    {
        public int NumberOfEmployees { get; set; }

        public string Desc { get; set; }
    }
}
