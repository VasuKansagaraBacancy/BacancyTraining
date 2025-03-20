using System.ComponentModel.DataAnnotations;

namespace Medicare__.DTO
{
    public class ReceptionistDTO
    {
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Qualification { get; set; }
    }
}
