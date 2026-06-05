using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Medication
    {
        public int MedicationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Effects { get; set; }
        [Display(Name="Side Effects")]
        public string? SideEffects { get; set; }
        public ICollection<PatientMedication> PatientMedications { get; set; }

    }
}
