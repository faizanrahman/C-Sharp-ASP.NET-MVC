using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage = "First Name must be atleast 4 characters long.")]
        public string FirstName{get;set;}
        [Required]
        [MinLength(4, ErrorMessage = "Last Name must be atleast 4 characters long.")]
        public string LastName{get;set;}
        [Required]
        public int Age{get;set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress{get;set;}
        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password{get;set;}
    }
}