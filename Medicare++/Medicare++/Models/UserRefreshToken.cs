using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medicare__.Models
{
    public class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User Id")]
        public Guid UserId { get; set; }  

        public User User { get; set; } = null!; 

        [Required]
        [MaxLength(500)]
        public string RefreshToken { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public bool IsRevoked { get; set; } = false;
    }
}