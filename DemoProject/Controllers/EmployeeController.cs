using DemoProject.API.Model.Domain;
using DemoProject.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;
using System.Net;
using DemoProject.API.Service;
using DemoProject.API.Repository;

namespace DemoProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {     
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails()
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await EmployeeRepository.GetEmployeeDetails();
            return Ok(response);
        }

        [HttpGet("/{Id}")]        
        public async Task<IActionResult> GetEmployeeDetailById(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await EmployeeRepository.GetEmployeeDetailByIds(Id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data. Please recheck!");
            }
            var response = await EmployeeRepository.AddEmployee(employeeRequest);
            return Ok(response);
        }
    }
}
