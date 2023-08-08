using DemoProject.API.Model.Domain;
using DemoProject.API.Data;
using DemoProject.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;
using System.Net;
using DemoProject.API.Service;
using DemoProject.API.ServiceRepository;

namespace DemoProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {     
        [HttpGet("Employees")]
        public async Task<IActionResult> GetEmployeeDetails()
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await EmployeeRepository.GetEmployeeDetails();
            return Ok(response);
        }

        [HttpGet("Employees/{id}")]        
        public async Task<IActionResult> GetEmployeeDetailById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await EmployeeRepository.GetEmployeeDetailByIds(id);
            return Ok(response);
        }
        [HttpPost("Employees")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await EmployeeRepository.AddEmployee(employeeRequest);
            return Ok(response);
        }
    }
}
