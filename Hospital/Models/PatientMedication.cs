using System.ComponentModel.DataAnnotations;
using Hospital.Models.Enums;

namespace Hospital.Models
{
    public class PatientMedication
    {
        public int PatientId { get; set; }
        public int MedicationId { get; set; }
        public Patient Patient { get; set; }
        public Medication Medication {  get; set; }
        [Required]
        public string Dose { get; set; }
        [Required]
        public string Frequency { get; set; }
        [Required]
        public DosageType DosageType { get; set; }
    }
}
