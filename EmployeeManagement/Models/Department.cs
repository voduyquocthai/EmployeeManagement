using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Department : ModelBase
    {
       
        public int ParentId { get; set; }

        [Required]
        public string Desc { get; set; }
    }
}
