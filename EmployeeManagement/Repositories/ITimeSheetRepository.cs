using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface ITimeSheetRepository : IRepository<TimeSheet>
    {

    }

    public class TimeSheetRepository : AbstractRepository<TimeSheet>, ITimeSheetRepository
    { 

    }
}
