using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface ITimeSheetRepository
    {
        IList<TimeSheet> GetAll();
        TimeSheet GetById(int id);
        int SearchByDateAndEmployee(DateTime date, Employee employee);
        void Insert(TimeSheet timeSheet);
        void Update(TimeSheet timeSheet);
        void Delete(TimeSheet timeSheet);
    }

    public class TimeSheetRepository : ITimeSheetRepository
    {
        protected static IList<TimeSheet> TimeSheets = new List<TimeSheet>();

        public static int Counter = 1;

        public IList<TimeSheet> GetAll()
        {
            return TimeSheets;
        }

        public TimeSheet GetById(int id)
        {
            return TimeSheets.FirstOrDefault(i => i.Id == id);
        }

        public int SearchByDateAndEmployee(DateTime date, Employee employee)
        {
            var searchTimeSheet = TimeSheets.FirstOrDefault(i => i.Date == date && i.Employee == employee);
            return searchTimeSheet != null ? searchTimeSheet.Id : 0;
        }

        public void Insert(TimeSheet timeSheet)
        {
            timeSheet.Id = Counter;
            Counter++;
            TimeSheets.Add(timeSheet);
        }

        public void Update(TimeSheet timeSheet)
        {
            var existingTimeSheet = TimeSheets.FirstOrDefault(i => i.Id == timeSheet.Id);
            if (existingTimeSheet == null) return;
            var index = TimeSheets.IndexOf(existingTimeSheet);
            TimeSheets[index] = timeSheet;
        }

        public void Delete(TimeSheet timeSheet)
        {
            TimeSheets.Remove(timeSheet);
        }
    }
}
