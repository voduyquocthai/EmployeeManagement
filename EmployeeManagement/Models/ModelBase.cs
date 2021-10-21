using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the name")]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        
    }
}