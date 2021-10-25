using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using EmployeeManagementTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EmployeeManagementTest.Test
{
    [TestClass]
    public class TimeSheetServiceTest
    {
        [Fact]
        public void GetAllTimeSheetsByEmployeeId_EmptyTimeSheets()
        {
            //Arrange
            var timeSheetRepoMock = new TimeSheetRepositoryMock().MockGetAll(new List<TimeSheet>());
            var timeSheetService = new TimeSheetService(timeSheetRepoMock.Object);

            //Act
            var result = timeSheetService.GetAllTimeSheetsByEmployeeId(1);

            //Assert
            Assert.IsTrue(result.Count == 0);
            timeSheetRepoMock.VerifyGetAll(Times.Once());
        }

        [Fact]
        public void GetAllTimeSheetsByEmployeeId_NotEmptyTimeSheets()
        {
            //Arrange
            var listTimeSheetMock = new List<TimeSheet>()
            {
                new TimeSheet()
                {
                    Id = 1,
                    Employee = new Employee()
                    {
                        Id = 1,
                        Name = "Thai"
                    }
                }
            };
            var timeSheetRepoMock = new TimeSheetRepositoryMock().MockGetAll(listTimeSheetMock);
            var timeSheetService = new TimeSheetService(timeSheetRepoMock.Object);

            //Act
            var result = timeSheetService.GetAllTimeSheetsByEmployeeId(1);

            //Assert
            Assert.IsTrue(result.Count == 1);
            timeSheetRepoMock.VerifyGetAll(Times.Once());
        }

        [Fact]
        public void AddTimeSheet_TimeSheetExisted()
        {
            //Arrange
            var timeSheet = new TimeSheet()
            {
                Id = 1,
                Employee = new Employee()
                {
                    Id = 1,
                    Name = "Thai"
                }
            };
            var timeSheetRepoMock = new TimeSheetRepositoryMock().MockSearchByDateAndEmployee(1);
            var timeSheetService = new TimeSheetService(timeSheetRepoMock.Object);

            //Act
            var result = timeSheetService.Add(timeSheet);

            //Assert
            Assert.IsTrue(result == false);
            timeSheetRepoMock.VerifySearchByDateAndEmployee(Times.Once());
        }

        [Fact]
        public void AddTimeSheet_TimeSheetAddSuccessfully()
        {
            //Arrange
            var timeSheet = new TimeSheet()
            {
                Id = 1,
                Employee = new Employee()
                {
                    Id = 1,
                    Name = "Thai"
                }
            };
            var timeSheetRepoMock = new TimeSheetRepositoryMock().MockSearchByDateAndEmployee(0);
            var timeSheetService = new TimeSheetService(timeSheetRepoMock.Object);

            //Act
            var result = timeSheetService.Add(timeSheet);

            //Assert
            Assert.IsTrue(result == true);
            timeSheetRepoMock.VerifySearchByDateAndEmployee(Times.Once());
            timeSheetRepoMock.VerifyInsert(Times.Once());
        }

        [Fact]
        public void TimeSheetServiceTest_Update()
        {
            //Setup
            var timeSheetRepoMock = new TimeSheetRepositoryMock().MockGetById(new TimeSheet()
            {
                Id = 1,
                Employee = new Employee()
                {
                    Id = 1,
                    Name = "Thai"
                }
            });

            var timeSheetService = new TimeSheetService(timeSheetRepoMock.Object);

            // Act
            timeSheetService.Update(new TimeSheet()
            {
                Id = 1,
                Employee = new Employee()
                {
                    Id = 3,
                    Name = "Tu"
                }
            });

            // Verify
            timeSheetRepoMock.VerifyGetById(Times.Once());
        }
    }
}
