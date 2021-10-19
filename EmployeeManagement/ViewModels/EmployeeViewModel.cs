using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel : ModelBase
    {
        [Required]
        public string Desc { get; set; }

        public string DateOfBirth { get; set; }

        public string YearsOfExperience { get; set; }

        public string PhoneNumber { get; set; }

        public int DepartmentId { get; set; }

        public IList<TimeSheet> TimeSheets { get; set; }
    }
}
