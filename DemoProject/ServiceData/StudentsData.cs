using DemoProject.Model.Domain;

namespace DemoProject.API.ServiceData
{
    public static class StudentsData
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student
                {
                    Id = 1,
                    Name ="A",
                    RollNo = 12,
                    Gender = "Male"
                },
                new Student
                {
                    Id = 2,
                    Name ="B",
                    RollNo = 123,
                    Gender = "Female"
                },
                new Student
                {
                    Id = 3,
                    Name ="C",
                    RollNo = 1234,
                    Gender = "Male"
                },
        };
    }
}
