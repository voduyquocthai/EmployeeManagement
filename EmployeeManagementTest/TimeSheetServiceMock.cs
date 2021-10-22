using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Moq;

namespace EmployeeManagementTest
{
    class TimeSheetServiceMock : Mock<ITimeSheetService>
    {
        public TimeSheetServiceMock MockAdd(bool result)
        {
            Setup(x => x.Add(It.IsAny<TimeSheet>())).Returns(result);
            return this;
        }

        public TimeSheetServiceMock VerifyAdd(Times times)
        {
            Verify(x => x.Add(It.IsAny<TimeSheet>()), times);
            return this;
        }
    }
}
