using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee : ModelBase
    {

        public Employee()
        {

        }
        public string Desc { get; set; }

        public string DateOfBirth { get; set; }
        [Range(0, 50, ErrorMessage = "Please provide an age between 25 and 70.")]
        public int YearsOfExperience { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please provide a valid phone number")]
        public string PhoneNumber { get; set; }

        public Department Department { get; set; }
    }
}