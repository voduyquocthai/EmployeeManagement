using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Department : ModelBase
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}
