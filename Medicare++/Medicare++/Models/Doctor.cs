    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    namespace Medicare__.Models
    {
        public class Doctor
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int DoctorId { get; set; }

            [Required]
            [ForeignKey("User")]
            public Guid UserId { get; set; }

            [Required]
            [ForeignKey("Specialization")]
            public int SpecializationId { get; set; }

            [Required]
            [MaxLength(100)]
            public string Qualification { get; set; } = string.Empty;

            [Required]
            [RegularExpression(@"^[A-Za-z0-9]{6,12}$", ErrorMessage = "License Number must be 6-12 alphanumeric characters.")]
            public string LicenseNumber { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public User? User { get; set; }

            public Specialization? Specialization { get; set; }
            public string CreatedBy { get; internal set; }
            public bool IsDeleted { get; set; } = false;
            public  ICollection<PatientNote> PatientNotes { get; set; }
        }
    }
