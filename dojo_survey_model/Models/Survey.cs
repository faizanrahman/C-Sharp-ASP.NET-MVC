using System.ComponentModel.DataAnnotations;

namespace dojo_survey_model.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2, ErrorMessage="Name must be atleast 2 characters")]
        public string Name{get;set;}
        public string Email{get;set;}
        [Required]
        public string Language{get;set;}
        [Required]
        public string Location{get;set;}
        [Required]
        [MaxLength(20)]
        public string Comments{get;set;}
    }
}