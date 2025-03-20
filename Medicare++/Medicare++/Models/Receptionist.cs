using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medicare__.Models
{
    public class Receptionist
    {
        [Key]
        public int ReceptionistId { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Required]
        [MaxLength(100)]
        public string Qualification { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
