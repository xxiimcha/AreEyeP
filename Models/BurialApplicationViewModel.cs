using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Required for IFormFile

namespace AreEyeP.Models
{
    public class BurialApplicationViewModel
    {
        // Applicant Information
        [Required]
        [Display(Name = "First Name")]
        public string ApplicantFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string ApplicantLastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Relationship to Deceased")]
        public string RelationshipToDeceased { get; set; }

        [Required]
        [Display(Name = "Contact Information")]
        public string ContactInformation { get; set; }

        // Deceased Information
        [Required]
        [Display(Name = "First Name")]
        public string DeceasedFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string DeceasedLastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string DeceasedGender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DeceasedDateOfBirth { get; set; }

        [Required]
        [Display(Name = "Date of Death")]
        [DataType(DataType.Date)]
        public DateTime DeceasedDateOfDeath { get; set; }

        [Required]
        [Display(Name = "Cause of Death")]
        public string CauseOfDeath { get; set; }

        [Required]
        [Display(Name = "Religion")]
        public string Religion { get; set; }

        // Burial Details
        [Required]
        [Display(Name = "Date of Burial")]
        [DataType(DataType.Date)]
        public DateTime BurialDate { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan BurialStartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public TimeSpan BurialEndTime { get; set; }

        [Display(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }

        // File upload field, this should be of type IFormFile for handling file uploads
        [Required(ErrorMessage = "The Attach Requirement field is required.")]
        [Display(Name = "Attach Requirement")]
        public IFormFile AttachedRequirement { get; set; }
    }
}
