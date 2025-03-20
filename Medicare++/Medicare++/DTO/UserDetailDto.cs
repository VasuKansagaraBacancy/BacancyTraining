namespace Medicare__.DTO
{
    public class UserDetailDto
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public DateOnly? DateOfRelieving { get; set; }

        public string MobileNo { get; set; } = string.Empty;
        public string? EmergencyNo { get; set; } = string.Empty;

        public bool Active { get; set; }
        public bool IsDeleted { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public RoleDto Role { get; set; } = new RoleDto();
        public List<UserRefreshTokenDto> RefreshTokens { get; set; } = new();
    }
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }

    public class UserRefreshTokenDto
    {
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
    }

}
