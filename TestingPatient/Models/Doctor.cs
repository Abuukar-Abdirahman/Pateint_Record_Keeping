using System.ComponentModel.DataAnnotations;

namespace TestingPatient.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        // Navigation properties

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
