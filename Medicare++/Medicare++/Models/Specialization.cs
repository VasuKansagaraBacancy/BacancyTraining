using System.ComponentModel.DataAnnotations;

namespace Medicare__.Models
{
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SpecializationName { get; set; } = string.Empty;

        [Required]
        public string? CreatedBy { get; set; } = null;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? UpdatedBy { get; set; } = null;

        public DateTime? UpdatedAt { get; set; } = null;

        public List<Doctor>? Doctors { get; set; }
    }
}
