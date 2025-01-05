using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingPatient.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Medication { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Dosage { get; set; }

        [MaxLength(255)]
        public string? Instructions { get; set; }

        // Foreign key
        [Required]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
