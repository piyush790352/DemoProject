using DemoProject.API.Model.Domain;
using DemoProject.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;


namespace DemoProject.API.Data
{
    public static class EmployeeData
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee { EmpId = EmployeeRepository.generateId(), EmpFirstName = "Ajit", EmpLastName = "Kumar",Gender="Male", EmpEmail = "ajit@gmail.com",IsEmployee=true });
            employees.Add(new Employee { EmpId = EmployeeRepository.generateId(), EmpFirstName = "Archana", EmpLastName = "Singh", Gender = "Male", EmpEmail = "archana@gmail.com", IsEmployee = true });
            employees.Add(new Employee { EmpId = EmployeeRepository.generateId(), EmpFirstName = "Anikt", EmpLastName = "Sharma", Gender = "Male", EmpEmail = "ankit@gmail.com", IsEmployee = true });
            employees.Add(new Employee { EmpId = EmployeeRepository.generateId(), EmpFirstName = "Roshni", EmpLastName = "Kumari", Gender = "Male", EmpEmail = "roshni@gmail.com", IsEmployee = true });
            employees.Add(new Employee { EmpId = EmployeeRepository.generateId(), EmpFirstName = "Richa", EmpLastName = "Das", Gender = "Male", EmpEmail = "richa@gmail.com", IsEmployee = true });
            return employees;
        }
    }

}
