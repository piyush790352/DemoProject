using DemoProject.API.Model.Domain;
using DemoProject.API.Service;
using System.Text.Json;

namespace DemoProject.API.Data
{
    public static class StudentsData
    {
        public static List<Student> GetStudents()
        {
            List<Student> Students = new List<Student>();

            Students.Add(new Student { StdId = StudentRepository.generateId(), StdFirstName = "Ajit", StdLastName = "Kumar", StdRollNo=12, Gender = "Male", StdEmail = "ajit@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = StudentRepository.generateId(), StdFirstName = "Archana", StdLastName = "Singh", StdRollNo=123, Gender = "Male", StdEmail = "archana@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = StudentRepository.generateId(), StdFirstName = "Anikt", StdLastName = "Sharma", StdRollNo=1234, Gender = "Male", StdEmail = "ankit@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = StudentRepository.generateId(), StdFirstName = "Roshni", StdLastName = "Kumari", StdRollNo=12345, Gender = "Male", StdEmail = "roshni@gmail.com", IsStudent = true });
            Students.Add(new Student { StdId = StudentRepository.generateId(), StdFirstName = "Richa", StdLastName = "Das", StdRollNo=123456, Gender = "Male", StdEmail = "richa@gmail.com", IsStudent = true });
            return Students;
        }

    }
}
