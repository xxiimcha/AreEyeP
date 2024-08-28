using System;
using System.ComponentModel.DataAnnotations;

namespace AreEyeP.Models
{
    public class BurialApplication
    {
        [Key]
        public int Id { get; set; }

        // Applicant Information
        [Required]
        [MaxLength(50)]
        public string ApplicantFirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApplicantLastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string RelationshipToDeceased { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactInformation { get; set; }

        // Deceased Information
        [Required]
        [MaxLength(50)]
        public string DeceasedFirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string DeceasedLastName { get; set; }

        [Required]
        public string DeceasedGender { get; set; }

        [Required]
        public DateTime DeceasedDateOfBirth { get; set; }

        [Required]
        public DateTime DeceasedDateOfDeath { get; set; }

        [Required]
        public string CauseOfDeath { get; set; }

        [Required]
        public string Religion { get; set; }

        // Burial Details
        [Required]
        public DateTime BurialDate { get; set; }

        [Required]
        public TimeSpan BurialStartTime { get; set; }

        [Required]
        public TimeSpan BurialEndTime { get; set; }

        public string SpecialInstructions { get; set; }

        public string AttachedRequirement { get; set; } // Path to the uploaded file
    }
}
