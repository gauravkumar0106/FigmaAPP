using DatingApp.API.Controllers;
using Figma.API.Data;
using Figma.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class TestController
    {
        private readonly IUserRepository _userRepo;
        public TestController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        #region Get Employee By Id 
        [Fact]
        public async void Task_GetEmployeeById_Return_OkResult()
        {

            //Arrange
            var controller = new UserController(_userRepo);
            var id = 1;

            //Act  
            var data = await controller.GetEmployee(1);

            //Assert  
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetEmployeeById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var id = 3;


            //Act  
            var data = await controller.GetEmployee(id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetEmployeeById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            int? id = null;

            //Act  
            var data = await controller.GetEmployee(id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        #region Get All Employee

        [Fact]
        public async void Task_GetEmployees_Return_OkResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);

            //Act  
            var data = await controller.GetEmployees();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetEmployees_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);

            //Act  
            var data = await controller.GetEmployees();
            data = null;

            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }

        #region Add New Employee  
        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var emp = new Employee() { EmpName = "Gaurav", EmpDesignation = "Developer", EmpDepartment = "BTS", EmpManager = "Praveen", EmpType = "Permanent" };

            //Act  
            var data = await controller.AddEmployee(emp);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var emp = new Employee() { EmpName = "Abhay", EmpDesignation = "Developer", EmpDepartment = "BTS", EmpManager = "Praveen", EmpType = "Contract" };

            //Act              
            var data = await controller.AddEmployee(emp);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        #region Update Existing Blog 

        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var id = 1;

            //Act  
            var existingEmp = await controller.GetEmployee(id);
            var okResult = existingEmp.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            var emp = new Employee();
            emp.EmpName = "Shrisha1";
            emp.EmpDesignation = "QA Tester";
            emp.EmpDepartment = "BTS";
            emp.EmpManager = "Praveen";
            emp.EmpType = "Permanent";

            var updatedData = await controller.UpdateEmployees(id,emp);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var id = 2;

            //Act  
            var existingEmp = await controller.GetEmployee(id);
            var okResult = existingEmp.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            var emp = new Employee();
            emp.EmpName = " ";
            emp.EmpDesignation = "QA Tester";
            emp.EmpDepartment = "BTS";
            emp.EmpManager = "Praveen";
            emp.EmpType = "Permanent";

            var data = await controller.UpdateEmployees(id, emp);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_NotFound()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var id = 12;

            //Act  
            var existingEmp = await controller.GetEmployee(id);
            var okResult = existingEmp.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            var emp = new Employee();
            emp.Id = 12;
            emp.EmpName = "shrisha";
            emp.EmpDesignation = "QA Tester";
            emp.EmpDepartment = "BTS";
            emp.EmpManager = "Praveen";
            emp.EmpType = "Permanent";

            var data = await controller.UpdateEmployees(id, emp);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        #region Delete Post
        [Fact]
        public async void Task_Delete_Employee_Return_OkResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var id = 1;

            //Act  
            var data = await controller.DeleteEmployees(id);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public async void Task_Delete_Employee_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            var id = 6;

            //Act  
            var data = await controller.DeleteEmployees(id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_Delete_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UserController(_userRepo);
            int? id = null;

            //Act  
            var data = await controller.DeleteEmployees(id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
    }
}

