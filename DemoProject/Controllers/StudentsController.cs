using DemoProject.API.Model.Domain;
using DemoProject.API.Data;
using DemoProject.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;
using System.Net;
using DemoProject.API.Service;
using DemoProject.API.Repository;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("Students")]
        public async Task<IActionResult> GetStudentDetails()
        {
            var response =  await StudentRepository.GetStudentDetail();
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpGet("Students/{id}")]
        public async Task<IActionResult> GetStudentDetailsById([FromRoute] int id)
        {
            var response = await StudentRepository.GetStudentDetailsByIds(id);
            
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpPost("Students")]
        public async Task<IActionResult> AddStudent([FromBody] Student studentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await StudentRepository.AddStudent(studentRequest);
            return Ok(response);
        }
    }
}
