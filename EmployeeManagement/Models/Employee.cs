using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee : ModelBase
    {
        [Required]
        public string Desc { get; set; }

        public string DateOfBirth { get; set; }

        public string YearsOfExperience { get; set; }

        public string PhoneNumber { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public IList<TimeSheet> TimeSheets { get; set; }
    }
}