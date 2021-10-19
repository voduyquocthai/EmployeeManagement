using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class TimeSheet : ModelBase
    {
        public string Desc { get; set; }

        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }
    }
}
