using DemoProject.API.Data;
using DemoProject.API.Model.Domain;
using DemoProject.Model.Domain;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.Design;
using System.Text.Json;

namespace DemoProject.API.Service
{
    public class StudentRepository
    {
        public static async Task<Response<List<Student>>> GetStudentDetail()
        {
            try
            {              
                var students = StudentsData.GetStudents().ToList();
                if(students != null)
                {
                    StudentsData.SaveStudent();
                    return new Response<List<Student>>
                    {
                        Result = students,
                        StatusMessage = "Ok"
                    };
                }
                else
                {
                    return new Response<List<Student>>
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

        public static async Task<Response<Student>> GetStudentDetailsByIds(int id)
        {
            try
            {
                var studentResult = StudentsData.GetStudents().FirstOrDefault(x => x.StdId == id);
                if (studentResult != null)
                {
                    return new Response<Student>
                    {
                        Result = studentResult,
                        StatusMessage = "Ok"
                    };
                }
                else
                {
                    return new Response<Student>
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

        public static async Task<Response<Student>> AddStudent(Student studentRequest)
        {
            try
            {
                var studentResult = new Student()
                {
                    StdId = studentRequest.StdId,
                    StdFirstName = studentRequest.StdFirstName,
                    StdLastName = studentRequest.StdLastName,
                    Gender = studentRequest.Gender,
                    StdRollNo = studentRequest.StdRollNo,
                    StdEmail = studentRequest.StdEmail,
                    IsStudent = studentRequest.IsStudent
                };
                if (studentResult != null)
                {
                    string text = File.ReadAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\StudentListJsonData\StudentJsonData.json");
                    var students = JsonSerializer.Deserialize<List<Student>>(text);
                    students.Add(studentResult);
                    string json = JsonSerializer.Serialize(students);
                    File.WriteAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\StudentListJsonData\StudentJsonData.json", json);
                    return new Response<Student>
                    {
                        Result = studentResult,
                        StatusMessage = "Ok"
                    };
                }
                else
                {
                    return new Response<Student>
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
}
}
