using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Figma.API.Data;
using Figma.API.Models;
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
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        // GET api/employees
        [HttpGet("employees")]
        public async  Task<IActionResult> GetEmployees()
        {
             //var employees = await _context.Employees.ToListAsync();
            var employees = await _userRepo.GetEmployees();

            return Ok(employees);
            
        }


        // GET api/user/5
        [HttpGet("employees/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try{
                // var employee = await _context.Employees.FirstOrDefaultAsync(x=>x.Id == id);
                var employee = await _userRepo.GetEmployee(id);

                if(employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
            
        }

        // POST api/user
        [HttpPost("employees/add")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            int result = 0;
            try{
                  //_context.Employees.Add(emp);
                //   result = await _context.SaveChangesAsync();
                result = await _userRepo.AddEmployee(emp);

                  if(result==0)
                  return NotFound();

                  return Ok(emp);
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
           
        

        }

        // PUT api/user/5
        [HttpPut("employees/{id}")]
        public async Task<IActionResult> UpdateEmployees(int id, [FromBody] Employee emp)
        {
            try{
                var employee = await _userRepo.GetEmployee(id);

             if(employee == null)
             {
                 return NotFound("Employee ID with"+ " " + id.ToString()+ "not found");
             }
             else {

                 var updatedemployee = _userRepo.UpdateEmployee(id,emp);
                 return Ok(updatedemployee);
             }
            }
            catch(Exception ex) {
                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            int result = 0;

            try{
                var employee = await _userRepo.GetEmployee(id);

                if(employee != null)
                // _context.Employees.Remove(employee);
                // result = await _context.SaveChangesAsync();
                result = await _userRepo.DeleteEmployees(employee);

                if(result == 0)
                return NotFound();

                return Ok();
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }
    }
}
