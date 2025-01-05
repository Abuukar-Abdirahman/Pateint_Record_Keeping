using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingPatient.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public ICollection<Billing>? Billings { get; set; }
    }
}
