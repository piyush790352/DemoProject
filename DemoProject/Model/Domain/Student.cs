namespace DemoProject.Model.Domain
{
    public class Student
    {
        public int StdId { get; set; }
        public string StdFirstName { get; set; }
        public string? StdLastName { get; set; }
        public int StdRollNo { get; set; }
        public String Gender { get; set; }
        public String? StdEmail { get; set; }
        public bool IsStudent { get; set; }
    }
}
