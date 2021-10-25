using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Moq;

namespace EmployeeManagementTest.Mocks
{
    public class TimeSheetRepositoryMock : Mock<ITimeSheetRepository>
    {
        public TimeSheetRepositoryMock MockGetById(TimeSheet result)
        {
            Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(result);
            return this;
        }

        public TimeSheetRepositoryMock MockGetByIdInvalid()
        {
            Setup(x => x.GetById(It.IsAny<int>()))
                .Throws(new Exception());
            return this;
        }

        public TimeSheetRepositoryMock VerifyGetById(Times times)
        {
            Verify(x => x.GetById(It.IsAny<int>()), times);
            return this;
        }

        public TimeSheetRepositoryMock MockGetAll(IList<TimeSheet> results)
        {
            Setup(x => x.GetAll())
                .Returns(results);
            return this;
        }

        public TimeSheetRepositoryMock VerifyGetAll(Times times)
        {
            Verify(x => x.GetAll(), times);
            return this;
        }

        public TimeSheetRepositoryMock MockSearchByDateAndEmployee(int i)
        {
            Setup(x => x.SearchByDateAndEmployee(It.IsAny<DateTime>(), It.IsAny<Employee>()))
                .Returns(i);
            return this;
        }

        public TimeSheetRepositoryMock VerifySearchByDateAndEmployee(Times times)
        {
            Verify(x => x.SearchByDateAndEmployee(It.IsAny<DateTime>(), It.IsAny<Employee>()), times);
            return this;
        }

        public TimeSheetRepositoryMock VerifyInsert(Times times)
        {
            Verify(x => x.Insert(It.IsAny<TimeSheet>()), times);
            return this;
        }
    }
}
