using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Figma.API.Data;
using Figma.API.Models;

namespace Figma.API.FigmaUnitTest
{
    public class UserRepoTest : IUserRepository
    {

        private readonly List<Employee> _employee;
        public UserRepoTest()
        {
            _employee = new List<Employee>()
            {
                new Employee() { Id = 1, EmpName = "Gaurav", EmpDesignation = "Developer", EmpDepartment="BTS",EmpManager="Praveen",EmpType="Permanent" },
                new Employee() { Id = 1, EmpName = "Abhay", EmpDesignation = "Senior Developer", EmpDepartment="BTS",EmpManager="Praveen",EmpType="Contract" },
                new Employee() { Id = 1, EmpName = "Shrisha", EmpDesignation = "QA Tester", EmpDepartment="BTS",EmpManager="Praveen",EmpType="Permanent" }
            };
        }
        public Task<int> AddEmployee(Employee emp)
        {
            _employee.Add(emp);
            return Task.Run(() => 1);
        }

        public Task<int> DeleteEmployees(Employee emp)
        {
            _employee.Remove(emp);
            return Task.Run(() => 1);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            //var employee = _employee.Where(x=>x.Id == id);

            var employee = await Task.Run(() => _employee.Where(x=>x.Id == id));

            return (Employee)employee;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await Task.Run(() => _employee);

            return employees;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee emp)
        {
            var employeeInDb = await GetEmployee(id);

            if(employeeInDb == null)
            {
                 return null;
            }
            else {
                 employeeInDb.EmpName = emp.EmpName;
                 employeeInDb.EmpDesignation = emp.EmpDesignation;
                 employeeInDb.EmpDepartment = emp.EmpDepartment;
                 employeeInDb.EmpManager = emp.EmpManager;
                 employeeInDb.EmpType = emp.EmpType;

                 return employeeInDb;
            }
           
        }
    }
}