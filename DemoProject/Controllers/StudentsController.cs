using DemoProject.API.ServiceData;
using DemoProject.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = StudentsData.Students.ToList();
            return Ok(students);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {           
            var studentResult = StudentsData.Students.FirstOrDefault(x => x.Id == id);
            if(studentResult == null)
            {
                return NotFound();
            }
            return Ok(studentResult);
        }
    }
}
