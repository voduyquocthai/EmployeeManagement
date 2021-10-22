using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Moq;

namespace EmployeeManagementTest
{
    class EmployeeServiceMock : Mock<IEmployeeService>
    {

        public EmployeeServiceMock MockGetAll(List<Employee> result)
        {
            Setup(x => x.GetAll()).Returns(result);
            return this;
        }

        public EmployeeServiceMock VerifyGetAll(Times times)
        {
            Verify(x => x.GetAll(), times);
            return this;
        }
        public EmployeeServiceMock MockGetById(Employee result)
        {
            Setup(x => x.GetById(It.IsAny<int>())).Returns(result);
            return this;
        }

        public EmployeeServiceMock VerifyGetById(Times times)
        {
            Verify(x => x.GetById(It.IsAny<int>()), times);
            return this;
        }


    }
}
