

using System.ComponentModel.DataAnnotations;

namespace DemoProject.API.Model.Domain
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only characters are allow.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "First Name must be at least 4 characters long and maximum upto 15 characters.")]
        public string StdFirstName { get; set; }

        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only characters are allow.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Last Name must be at least 4 characters long and maximum upto 15 characters.")]
        public string? StdLastName { get; set; }

        [Required(ErrorMessage = "RollNo. is required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allow.")]
        public int StdRollNo { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only characters are allow.")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Gender Must be at least 4 characters long and maximum upto 8 characters.")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address (Email address must be in the form of user@xyz.com).")]
        public String? StdEmail { get; set; }
        public bool IsStudent { get; set; }
    }
}
