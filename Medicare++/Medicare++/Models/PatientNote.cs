using System.ComponentModel.DataAnnotations;

namespace Medicare__.Models
{
    public class PatientNote
    {
        [Key]
        public int PatientNoteId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required]
        [StringLength(1000)]
        public string NoteText { get; set; }

        [Required]
        public string CreatedBy { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Appointment Appointment { get; set; }
    }
}
