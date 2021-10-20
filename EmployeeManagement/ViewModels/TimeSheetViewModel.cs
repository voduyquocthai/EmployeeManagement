using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class TimeSheetViewModel
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }
        public int HoursOfWork { get; set; }
        public int EmployeeId { get; set; }
    }
}
