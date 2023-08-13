using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace DemoProject.API.Model.Domain
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only characters are allow.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "First Name must be at least 4 characters long and maximum upto 15 characters.")]
        public string EmpFirstName { get; set; }

        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only characters are allow.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Last Name must be at least 4 characters long and maximum upto 15 characters.")]
        public string? EmpLastName { get; set; }

        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only characters are allow.")]
        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Gender Must be at least 4 characters long and maximum upto 8 characters.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address (Email address must be in the form of user@xyz.com).")]
        public string? EmpEmail { get; set; }

        public bool IsEmployee { get; set; }

        
    }
}
