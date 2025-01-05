using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TestingPatient.Models
{
    public class MedicalRecordViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Record Date")]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        // Dropdown list for Patients
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
