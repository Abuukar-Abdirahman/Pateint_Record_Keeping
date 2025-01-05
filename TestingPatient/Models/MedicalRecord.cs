using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingPatient.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }

        // Foreign key
        [Required]

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
