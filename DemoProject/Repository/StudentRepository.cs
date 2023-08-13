using DemoProject.API.Data;
using DemoProject.API.Model.Domain;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoProject.API.Service
{
    public class StudentRepository
    {
        public static async Task<Response<List<Student>>> GetStudentDetail()
        {
            try
            {
                string text = File.ReadAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\StudentListJsonData\StudentJsonData.json");
                var student = JsonSerializer.Deserialize<List<Student>>(text);
                if (student.Count == 0)
                {
                    var students = StudentsData.GetStudents().ToList();
                    if (students != null)
                    {
                        string json = JsonSerializer.Serialize(students);
                        File.WriteAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\StudentListJsonData\StudentJsonData.json", json);
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
                            StatusMessage = "No record found.!"
                        };
                    }
                }
                else
                {
                    return new Response<List<Student>>
                    {
                        Result = student,
                        StatusMessage = "Ok"
                    };
                }

            }
            catch(Exception ex) 
            {
                throw ex;
            }           
        }

        public static async Task<Response<Student>> GetStudentDetailsByIds(int Id)
        {
            try
            {
                string text = File.ReadAllText(@"C:\Users\HP\source\repos\DemoProject\DemoProject\Json\StudentListJsonData\StudentJsonData.json");
                var student = JsonSerializer.Deserialize<List<Student>>(text);
                var studentResult = student.FirstOrDefault(x => x.StdId == Id);
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
        public static async Task<Response<Student>> AddStudent(Student studentRequest)
        {
            try
            {
                var studentResult = new Student()
                {
                    StdId = generateId(),
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
                    foreach (var item in students)
                    {
                        if (item.StdId == studentRequest.StdId)
                        {
                            return new Response<Student>
                            {
                                StatusMessage = "This record already exist."
                            };
                        }
                    }
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
