using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TestingPatient.Models
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Medication { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Dosage { get; set; }

        [MaxLength(255)]
        public string? Instructions { get; set; }

        [Required]
        [Display(Name = "Appointment")]
        public int AppointmentId { get; set; }

        // Dropdown list for Appointments
        public IEnumerable<SelectListItem> Appointments { get; set; }
    }
}
