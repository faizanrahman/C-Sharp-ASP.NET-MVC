using System.ComponentModel.DataAnnotations;

namespace dojo_survey_validation.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage="Name must be atleast 2 characters")]
        public string Name{get;set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{get;set;}
        [Required]
        public string Language{get;set;}
        [Required]
        public string Location{get;set;}
        [MaxLength(20)]
        public string Comments{get;set;}
    }
}