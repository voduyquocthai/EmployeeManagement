using System;

namespace EmployeeManagement.Models
{
    public class Employee : ModelBase
    {
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class TimeSheet : ModelBase
    {
        public string Desc { get; set; }
    }
}