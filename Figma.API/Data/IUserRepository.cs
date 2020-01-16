using System.Collections.Generic;
using System.Threading.Tasks;
using Figma.API.Models;

namespace Figma.API.Data
{
    public interface IUserRepository
    {
         Task<List<Employee>> GetEmployees();
         Task<Employee> GetEmployee(int id);

         Task<int> AddEmployee(Employee emp);

         Task<Employee> UpdateEmployee(int id, Employee emp);

         Task<int> DeleteEmployees(Employee emp);
    }
}