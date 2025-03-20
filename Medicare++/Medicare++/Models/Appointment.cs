using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicare__.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [ForeignKey("PatientId")]
        [Required]
        public int PatientId { get; set; }

        [ForeignKey("DoctorId")]
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentStarts { get; set; }

        [Required]
        public DateTime AppointmentEnds { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(500)]
        public string AppointmentDescription { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Patient Patient { get; set; }
        public  Doctor Doctor { get; set; }
        public ICollection<PatientNote> PatientNotes { get; set; }
    }
}
