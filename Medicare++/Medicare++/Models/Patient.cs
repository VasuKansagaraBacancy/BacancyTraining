using Microsoft.Exchange.WebServices.Data;
using System.ComponentModel.DataAnnotations;

namespace Medicare__.Models
{
    public class Patient
    {
        [Key]
        [Required]
        [StringLength(9, MinimumLength = 9)]
        public int PatientId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "Aadhar number must be 12 digits.")]
        public string AadharNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^\+91[6-9]\d{9}$", ErrorMessage = "Phone number must be a valid Indian number with +91 prefix.")]
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool Active { get; set; } = true;

        [Required]
        public string CreatedBy { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public  ICollection<Appointment> Appointments { get; set; }
        public  ICollection<PatientNote> PatientNotes { get; set; }
   
    }
}
