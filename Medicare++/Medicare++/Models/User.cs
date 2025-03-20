    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Medicare__.Models
    {
        public class User
        {
            [Key]
            public Guid UserId { get; set; } = Guid.NewGuid();

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

            [Required]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
            public string MobileNo { get; set; } = string.Empty;

            [Required]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string? EmergencyNo { get; set; }

            [Required]
            [Column(TypeName = "nvarchar(100)")]
            public string Password { get; set; } = string.Empty;

            [Required]
            public int RoleId { get; set; }
            [ForeignKey("RoleId")]
            public Role Role { get; set; } = null!;
            public bool Active { get; set; } = true;
            public string? CreatedBy { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public string? UpdatedBy { get; set; }

            public DateTime? UpdatedAt { get; set; }
            public bool IsDeleted { get; set; } = false;
            public DateTime? DeletedAt { get; set; }
            public string? DeletedBy { get; set; }

            public List<UserRefreshToken> UserRefreshTokens { get; set; } = new List<UserRefreshToken>();
            public Doctor? Doctor { get; set; }
            public Receptionist Receptionist { get; set; }
    }
    }