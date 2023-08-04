using DemoProject.API.Model.Domain;
using DemoProject.Model.Domain;

namespace DemoProject.API.ServiceData
{
    public static class EmployeeData
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>()
        {
            new Employee
                {
                    EmpId = 1,
                    EmpName ="A",                   
                    Gender = "Male"
                },
                new Employee
                {
                    EmpId = 2,
                    EmpName ="B",                 
                    Gender = "Female"
                },
                new Employee
                {
                    EmpId = 3,
                    EmpName ="C",
                    Gender = "Male"
                },
        };
    }
}
