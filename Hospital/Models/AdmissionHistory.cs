using System.ComponentModel.DataAnnotations;
using Hospital.Models.Enums;

namespace Hospital.Models
{
    public class AdmissionHistory
    {
        public int Id { get; set; }

        // Original patient ID kept for reference
        public int OriginalPatientId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Diagnosis { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; } = default!;

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = default!;

        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        public string? Allergies { get; set; }

        // Date the patient was discharged / removed
        [Display(Name = "Discharged On")]
        public DateTime DischargedOn { get; set; }
    }
}
