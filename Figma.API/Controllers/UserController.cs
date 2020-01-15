using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Figma.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        // GET api/employees
        [HttpGet("employees")]
        public async  Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            return Ok(employees);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=>x.Id == id);

            return Ok(employee);
        }

        // POST api/values
        [HttpPost]
        public void AddEmployee([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateEmployees(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteEmployees(int id)
        {
        }
    }
}
