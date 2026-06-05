using System.ComponentModel.DataAnnotations;
using Hospital.Models.Enums;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        [Range(1, 10, ErrorMessage = "Room number must be between 1 and 10.")]
        public int RoomNumber { get; set; }

        [Required]
        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        public string? Allergies { get; set; }
        [Required]
        public string Diagnosis { get; set;  }
    }
}
