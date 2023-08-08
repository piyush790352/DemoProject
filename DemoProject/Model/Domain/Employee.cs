namespace DemoProject.API.Model.Domain
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string? EmpLastName { get; set; }
        public string Gender { get; set; }
        public string? EmpEmail { get; set; }
        public bool IsEmployee { get; set; }
    }
}
