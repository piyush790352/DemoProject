using DemoProject.API.Model.Domain;
using DemoProject.Model.Domain;
using System.Text.Json;

namespace DemoProject.API.Data
{
    public static class StudentsData
    {
        public static bool SaveStudent()
        {
            List<Student> Students = GetStudents();
            if (Students.Count == 0)
            {
                return false;
            }
            string json = JsonSerializer.Serialize(Students);
            File.WriteAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\StudentJsonData\StudentListJsonData.json", json);
            return true;
        }

        public static List<Student> GetStudents()
        {
            List<Student> Students = new List<Student>();

            Students.Add(new Student { StdId = 1, StdFirstName = "Ajit", StdLastName = "Kumar", Gender = "Male", StdEmail = "ajit@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = 2, StdFirstName = "Archana", StdLastName = "Singh", Gender = "Male", StdEmail = "archana@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = 3, StdFirstName = "Anikt", StdLastName = "Sharma", Gender = "Male", StdEmail = "ankit@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = 4, StdFirstName = "Roshni", StdLastName = "Kumari", Gender = "Male", StdEmail = "roshni@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = 5, StdFirstName = "Richa", StdLastName = "Das", Gender = "Male", StdEmail = "richa@gmail.com", IsStudent = true });
            return Students;
        }

    }
}
