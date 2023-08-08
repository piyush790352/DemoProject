using DemoProject.API.Model.Domain;
using DemoProject.Model.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;


namespace DemoProject.API.Data
{
    public static class EmployeeData
    {

        public static bool SaveEmployee()
        {
            List<Employee> employees = GetEmployees();
            if (employees.Count == 0) {
                return false;
            }
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\EmployeeJsonData\EmployeeListJsonData.json", json);
            return true;
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee { EmpId = 1, EmpFirstName = "Ajit", EmpLastName = "Kumar",Gender="Male", EmpEmail = "ajit@gmail.com",IsEmployee=true });
            employees.Add(new Employee { EmpId = 2, EmpFirstName = "Archana", EmpLastName = "Singh", Gender = "Male", EmpEmail = "archana@gmail.com", IsEmployee = true });
            employees.Add(new Employee { EmpId = 3, EmpFirstName = "Anikt", EmpLastName = "Sharma", Gender = "Male", EmpEmail = "ankit@gmail.com", IsEmployee = true });
            employees.Add(new Employee { EmpId = 4, EmpFirstName = "Roshni", EmpLastName = "Kumari", Gender = "Male", EmpEmail = "roshni@gmail.com", IsEmployee = true });
            employees.Add(new Employee { EmpId = 5, EmpFirstName = "Richa", EmpLastName = "Das", Gender = "Male", EmpEmail = "richa@gmail.com", IsEmployee = true });
            return employees;
        }
    }

}
