using System.ComponentModel.DataAnnotations;

namespace Medicare__.Model_DTO
{
    public class UserDto
    {
        [Required, StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public DateOnly DateOfJoining { get; set; }

        public DateOnly? DateOfRelieving { get; set; }

        [Required, Phone, StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number should not exceed 10 digits.")]
        public string MobileNo { get; set; } = string.Empty;

        [Phone, StringLength(10, MinimumLength = 10, ErrorMessage = "Emergency contact should not exceed 10 digits.")]
        public string? EmergencyNo { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "RoleId must be 1 (Admin), 2 (Doctor), or 3 (Receptionist).")]
        public int RoleId { get; set; }
    }
}
