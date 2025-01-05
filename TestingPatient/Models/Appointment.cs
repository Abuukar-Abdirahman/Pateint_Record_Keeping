using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingPatient.Models
{
    public class Appointment
    {
        //public int Id { get; set; }
        //public int PatientId { get; set; }
        //public Patient Patient { get; set; }
        //public int DoctorId { get; set; }
        //public Doctor Doctor { get; set; }
        //public DateTime AppointmentDate { get; set; }
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(255)]
        public string Reason { get; set; }

        // Foreign keys
        [Required]
       
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        // Navigation properties
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }

        public ICollection<Prescription>? Prescription { get; set; }
    }
}
