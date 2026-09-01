using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FeedbackApp.Models
{
    public class Experience
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type of entity is required")]
        public string TypeOfEntity { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public int RegionId { get; set; }

        [ValidateNever]
        public Region Region { get; set; }

        [Required(ErrorMessage = "Wilaya is required")]
        public int WilayaId { get; set; }

        [ValidateNever]
        public Wilaya Wilaya { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public int AreaId { get; set; }

        [ValidateNever]
        public Area Area { get; set; }

        [Required(ErrorMessage = "Village is required")]
        public int VillageId { get; set; }

        [ValidateNever]
        public Village Village { get; set; }

        [Required(ErrorMessage = "Details of Open Data Experience is required")]
        public string DetailsOfExperience { get; set; }

        [Required(ErrorMessage = "Remarks and suggestions are required")]
        public string RemarksAndSuggestions { get; set; }
    }
}