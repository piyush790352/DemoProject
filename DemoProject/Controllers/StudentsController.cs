using DemoProject.API.Model.Domain;
using DemoProject.API.Data;
using DemoProject.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;
using System.Net;

namespace DemoProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("/Students")]
        public IActionResult GetAll()
        {
            var students = StudentsData.Students.ToList();
            return Ok(students);
        }
        [HttpGet]
        [Route("/Students/{id}")]
        public IActionResult GetById(int id)
        {           
            var studentResult = StudentsData.Students.FirstOrDefault(x => x.Id == id);
            if(studentResult == null)
            {
                return this.NotFound("No Record found.");
            }
            return Ok(studentResult);
        }

        [HttpGet("/Employees")]
        public IActionResult GetEmpAll()
        {
            var empResult = EmployeeData.Employees.ToList();
            return Ok(empResult);
        }
        [HttpGet]
        [Route("/Employees/{id}")]
        public IActionResult GetEmpById(int id)
        {
            var empResult = EmployeeData.Employees.FirstOrDefault(x => x.EmpId == id);
            if (empResult == null)
            {
                return this.NotFound("No Record found.");
            }
            return Ok(empResult);
        }
    }
}
