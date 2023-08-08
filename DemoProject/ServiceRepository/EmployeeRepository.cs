using DemoProject.API.Data;
using DemoProject.API.Model.Domain;
using DemoProject.Model.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoProject.API.ServiceRepository
{
    public class EmployeeRepository
    {
        public static async Task<Response<List<Employee>>> GetEmployeeDetails()
        {
            try
            {
                var employees = EmployeeData.GetEmployees().ToList();
                if (employees != null)
                {
                    StudentsData.SaveStudent();
                    return new Response<List<Employee>>
                    {
                        Result = employees,
                        StatusMessage = "Ok"
                    };
                }
                else
                {
                    return new Response<List<Employee>>
                    {
                        StatusMessage = "No Data found..!"
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Response<Employee>> GetEmployeeDetailByIds(int id)
        {
            try
            {
                var employeeResult = EmployeeData.GetEmployees().FirstOrDefault(x => x.EmpId == id);
                if (employeeResult != null)
                {                   
                    return new Response<Employee>
                    {
                        Result = employeeResult,
                        StatusMessage = "Ok"
                    };
                }
                else
                {
                    return new Response<Employee>
                    {
                        StatusMessage = "No Data found..!"
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Response<Employee>> AddEmployee(Employee employeeRequest)
        {
            try
            {                
                var employees =  new Employee()
                {
                    EmpId = employeeRequest.EmpId,
                    EmpFirstName = employeeRequest.EmpFirstName,
                    EmpLastName = employeeRequest.EmpLastName,
                    Gender = employeeRequest.Gender,
                    EmpEmail = employeeRequest.EmpEmail,
                    IsEmployee = employeeRequest.IsEmployee
                };
                if (employees != null)
                {
                    string json = JsonSerializer.Serialize(employees);
                    File.WriteAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\EmployeeJsonData\EmployeeJsonData.json", json);
                    return new Response<Employee>
                    {
                        Result = employees,
                        StatusMessage = "Ok"
                    };                                      
                }
                else
                {
                    return new Response<Employee>
                    {
                        StatusMessage = "No Data found..!"
                    };
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }       
    }
}
