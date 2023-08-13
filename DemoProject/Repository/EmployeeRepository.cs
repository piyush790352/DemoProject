using DemoProject.API.Data;
using DemoProject.API.Model.Domain;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoProject.API.Repository
{
    public class EmployeeRepository
    {
        public static async Task<Response<List<Employee>>> GetEmployeeDetails()
        {
            try
            {
                string text = File.ReadAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\EmployeeListJsonData\EmployeeJsonData.json");
                var employee = JsonSerializer.Deserialize<List<Employee>>(text);
                if (employee.Count == 0)
                {
                    var employees = EmployeeData.GetEmployees().ToList();
                    if (employees != null)
                    {
                        string json = JsonSerializer.Serialize(employees);
                        File.WriteAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\EmployeeListJsonData\EmployeeJsonData.json", json);
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
                            StatusMessage = "No recored found!."
                        };
                    }
                }
                else
                {
                    return new Response<List<Employee>>
                    {
                        Result = employee,
                        StatusMessage = "Ok"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Response<Employee>> GetEmployeeDetailByIds(int Id)
        {
            try
            {
                string text = File.ReadAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\EmployeeListJsonData\EmployeeJsonData.json");
                var employee = JsonSerializer.Deserialize<List<Employee>>(text);
                var employeeResult = employee.FirstOrDefault(x => x.EmpId == Id);
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
                        StatusMessage = "No record found.!"
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static int id = 1;
        public static int generateId()
        {
            return id++;
        }

        public static async Task<Response<Employee>> AddEmployee(Employee employeeRequest)
        {
            try
            {
                var employee = new Employee()
                {
                    EmpId = generateId(),
                    EmpFirstName = employeeRequest.EmpFirstName,
                    EmpLastName = employeeRequest.EmpLastName,
                    Gender = employeeRequest.Gender,
                    EmpEmail = employeeRequest.EmpEmail,
                    IsEmployee = employeeRequest.IsEmployee
                };
                if (employee != null)
                {
                    string text = File.ReadAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\EmployeeListJsonData\EmployeeJsonData.json");
                    var employees = JsonSerializer.Deserialize<List<Employee>>(text);
                    foreach (var item in employees)
                    {
                        if (item.EmpId == employeeRequest.EmpId)
                        {
                            return new Response<Employee>
                            {
                                StatusMessage = "This record already exist."
                            };
                        }
                    }
                    employees.Add(employee);
                    string json = JsonSerializer.Serialize(employees);
                    File.WriteAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\EmployeeListJsonData\EmployeeJsonData.json", json);

                    return new Response<Employee>
                    {
                        Result = employee,
                        StatusMessage = "Ok"
                    };
                }
                else
                {
                    return new Response<Employee>
                    {
                        StatusMessage = "No Record found..!"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
