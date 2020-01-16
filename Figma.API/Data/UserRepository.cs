using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Figma.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Figma.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> AddEmployee(Employee emp)
        {
           _context.Employees.Add(emp);
           int result = await _context.SaveChangesAsync();

           return result;
        }

        public async Task<int> DeleteEmployees(Employee emp)
        {
            _context.Employees.Remove(emp);
            int result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=>x.Id == id);
            return employee;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employee = await _context.Employees.ToListAsync();

            return employee;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee emp)
        {
             var employee = await _context.Employees.FirstOrDefaultAsync(x=>x.Id == id);

             if(employee == null)
             {
                 return null;
             }
             else {
                 employee.EmpName = emp.EmpName;
                 employee.EmpDesignation = emp.EmpDesignation;
                 employee.EmpDepartment = emp.EmpDepartment;
                 employee.EmpManager = emp.EmpManager;
                 employee.EmpType = emp.EmpType;

                 _context.SaveChanges();
             }

             return employee;
        }
    }
}