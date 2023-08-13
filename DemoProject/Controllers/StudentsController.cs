using DemoProject.API.Model.Domain;
using DemoProject.API.Data;
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
        [HttpGet("Student")]
        public async Task<IActionResult> GetStudentDetails()
        {
            var response =  await StudentRepository.GetStudentDetail();
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpGet("Student/{Id}")]
        public async Task<IActionResult> GetStudentDetailsById(int Id)
        {
            var response = await StudentRepository.GetStudentDetailsByIds(Id);
            
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpPost("Student")]
        public async Task<IActionResult> AddStudent([FromBody] Student studentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data. Please recheck!");
            }
            var response = await StudentRepository.AddStudent(studentRequest);
            return Ok(response);
        }
    }
}
