using System;
using System.Collections.Generic;
using System.Globalization;
using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using EmployeeManagement.ViewModels;
using EmployeeManagementTest.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace EmployeeManagementTest.Test
{
    [TestClass]
    public class TimeSheetControllerTest
    {
        public Mock<IEmployeeService> EmployeeServiceMock = new Mock<IEmployeeService>();
        public Mock<ITimeSheetService> TimeSheetServiceMock = new Mock<ITimeSheetService>();

        [Fact]
        public void Store_Get_Valid()
        {
            //Set Up
            EmployeeServiceMock.Setup(x => x.GetAll()).Returns(new List<Employee>());
            var controller = new TimeSheetController(EmployeeServiceMock.Object, TimeSheetServiceMock.Object);
            //Act
            var result = controller.Store();
            //Verify
            Assert.IsAssignableFrom<ViewResult>(result);
            EmployeeServiceMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void Store_Post_ModelState_NotValid()
        {
            
            //Set Up
            var employee = new Employee()
            {
                Id = 1,
                Name = "Thai",
                Desc = "Dev"
            };

            var model = new TimeSheetViewModel()
            {
                Id = 1,
                EmployeeId = 1
            };

            EmployeeServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(employee);
            
            var controller = new TimeSheetController(EmployeeServiceMock.Object, TimeSheetServiceMock.Object);
            controller.ModelState.AddModelError("test", "test");

            //Act
            var result = controller.Store(model);
            //Verify
            Assert.IsAssignableFrom<ViewResult>(result);
            EmployeeServiceMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Store_Post_ModelState_Valid_Add_Successful()
        {
            //Set Up
            var model = new TimeSheetViewModel()
            {
                Id = 1,
                EmployeeId = 1
            };
            EmployeeServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Employee());
            TimeSheetServiceMock.Setup(x => x.Add(It.IsAny<TimeSheet>())).Returns(true);
            var controller = new TimeSheetController(EmployeeServiceMock.Object, TimeSheetServiceMock.Object);

            //Act
            var result = controller.Store(model);

            //Verify
            EmployeeServiceMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            TimeSheetServiceMock.Verify(x => x.Add(It.IsAny<TimeSheet>()), Times.Once);
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            var redirectToAction = (RedirectToActionResult)result;
            Assert.Equal("Details", redirectToAction.ActionName);
        }

        [Fact]
        public void Store_Post_ModelState_Valid_Add_Unsuccessful()
        {
            //Set Up
            var model = new TimeSheetViewModel()
            {
                Id = 1,
                EmployeeId = 1
            };
            EmployeeServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Employee());
            EmployeeServiceMock.Setup(x => x.GetAll()).Returns(new List<Employee>());
            TimeSheetServiceMock.Setup(x => x.Add(It.IsAny<TimeSheet>())).Returns(false);
            var controller = new TimeSheetController(EmployeeServiceMock.Object, TimeSheetServiceMock.Object);

            //Act
            var result = controller.Store(model);

            //Verify
            EmployeeServiceMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            EmployeeServiceMock.Verify(x => x.GetAll(), Times.Once);
            TimeSheetServiceMock.Verify(x => x.Add(It.IsAny<TimeSheet>()), Times.Once);
            Assert.IsAssignableFrom<ViewResult>(result);
        }
    }
}
