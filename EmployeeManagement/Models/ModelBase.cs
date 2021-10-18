using System;

namespace EmployeeManagement.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
    }
}