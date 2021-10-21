using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Services
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepository;

        public TimeSheetService(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        public IList<TimeSheet> GetAll()
        {
            return _timeSheetRepository.GetAll();
        }

        public bool Add(TimeSheet timeSheet)
        {
            var identity = _timeSheetRepository.SearchByDateAndEmployee(timeSheet.Date, timeSheet.Employee);

            if (identity != 0)
            {
                return false;
            }

            _timeSheetRepository.Insert(timeSheet);
            return true;
        }

        public TimeSheet GetById(int id)
        {
            return _timeSheetRepository.GetById(id);
        }

        public void Update(TimeSheet timeSheet)
        {
            var existTimeSheet = _timeSheetRepository.GetById(timeSheet.Id);
            existTimeSheet.Date = timeSheet.Date;
            existTimeSheet.Employee = timeSheet.Employee;
            existTimeSheet.Desc = timeSheet.Desc;
            existTimeSheet.HoursOfWork = timeSheet.HoursOfWork;
        }

        public void Delete(int id)
        {
            var timeSheet = _timeSheetRepository.GetById(id);
            if (timeSheet != null)
            {
                _timeSheetRepository.Delete(timeSheet);
            }
        }

        public List<TimeSheet> GetAllTimeSheetsByEmployeeId(int id)
        {
            var timeSheets = _timeSheetRepository.GetAll();
            return timeSheets.Where(t => t.Employee.Id == id).ToList();
        }
    }
}
