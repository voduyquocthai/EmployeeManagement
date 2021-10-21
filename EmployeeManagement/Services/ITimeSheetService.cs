using System.Collections.Generic;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface ITimeSheetService
    {
        public IList<TimeSheet> GetAll();

        public bool Add(TimeSheet timeSheet);

        public TimeSheet GetById(int id);

        public void Update(TimeSheet model);

        public void Delete(int id);

        public List<TimeSheet> GetAllTimeSheetsByEmployeeId(int id);
    }
}