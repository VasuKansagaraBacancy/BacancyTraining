using Medicare__.DTO;
using Medicare__.Model_DTO;
using Medicare__.Models;
using Medicare__.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medicare__.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly EmailService _emailService;
        private readonly IConfiguration _configuration;
        private static readonly Random random = new();

        public UserService(IUserRepository repository, EmailService emailService, IConfiguration configuration)
        {
            _repository = repository;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<string> AddUserAsync(UserDto userDto, string adminId)
        {
            if (!new[] { 1, 2, 3 }.Contains(userDto.RoleId))
                return "Invalid Role ID. Must be 1 (Admin), 2 (Doctor), or 3 (Receptionist).";

            string generatedPassword = GenerateRandomPassword(6);

            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                DateOfBirth = userDto.DateOfBirth,
                DateOfJoining = userDto.DateOfJoining,
                DateOfRelieving = userDto.DateOfRelieving,
                MobileNo = userDto.MobileNo,
                EmergencyNo = userDto.EmergencyNo,
                Password = BCrypt.Net.BCrypt.HashPassword(generatedPassword),
                RoleId = userDto.RoleId,
                Active = true,
                CreatedBy = adminId,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(newUser);

            string resetToken = GenerateJwtToken(newUser.Email);
            string resetLink = $"https://localhost:7039/swagger/index.html#/api/user/reset-password?token={resetToken}";

            _emailService.SendEmail(newUser, generatedPassword, resetLink);

            return "User added successfully. Email sent.";
        }

        public async Task<string> RequestPasswordResetAsync(string email)
        {
            var user = await _repository.GetByEmailAsync(email);
            if (user == null)
                return "User not found.";

            string resetToken = GenerateJwtToken(user.Email);
            string resetLink = $"https://localhost:7039/swagger/index.html#/api/user/reset-password?token={resetToken}";

            _emailService.SendResetPasswordEmail(user, resetLink);

            return "Password reset link sent.";
        }

        public async Task<string> ResetPasswordAsync(string token, string newPassword)
        {
            var email = ValidateJwtToken(token);
            if (email == null) return "Invalid or expired token.";

            var user = await _repository.GetByEmailAsync(email);
            if (user == null) return "User not found.";

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _repository.UpdateAsync(user);

            _emailService.SendPasswordChangedEmail(user, newPassword);

            return "Password reset successfully.";
        }

        public async Task<string> SoftDeleteUserAsync(Guid userId, string adminId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user == null) return "User not found.";

            user.DeletedBy = adminId;
            await _repository.SoftDeleteAsync(user);

            return "User soft deleted successfully.";
        }

        public async Task<string> PermanentDeleteUserAsync(Guid userId)
        {
            var user = await _repository.GetByIdWithoutFilterAsync(userId);

            if (user == null)
                return "User not found.";

            await _repository.PermanentDeleteAsync(user);

            return "User permanently deleted successfully.";
        }

        public async Task<object> UpdateUserAsync(Guid userId, UserDto updatedUserDto, string adminId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user == null) return "User not found.";

            user.FirstName = updatedUserDto.FirstName;
            user.LastName = updatedUserDto.LastName;
            user.Email = updatedUserDto.Email;
            user.DateOfBirth = updatedUserDto.DateOfBirth;
            user.DateOfJoining = updatedUserDto.DateOfJoining;
            user.DateOfRelieving = updatedUserDto.DateOfRelieving;
            user.MobileNo = updatedUserDto.MobileNo;
            user.EmergencyNo = updatedUserDto.EmergencyNo;
            user.RoleId = updatedUserDto.RoleId;
            user.UpdatedBy = adminId;
            user.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(user);

            return new { message = "User updated successfully", user };
        }

        private string GenerateJwtToken(string email)
        {
            var key = Encoding.ASCII.GetBytes("your_secret_key_hereyour_secret_key_here");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string? ValidateJwtToken(string token)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes("your_secret_key_hereyour_secret_key_here");
                var tokenHandler = new JwtSecurityTokenHandler();

                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out _);

                return principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            }
            catch
            {
                return null;
            }
        }

        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<UserDetailDto> GetUserByIdAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId cannot be empty.");

            var user = await _repository.GetUserByIdAsync(userId);

            if (user == null)
                throw new KeyNotFoundException($"User not found with Id {userId}");

            var userDto = new UserDetailDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                DateOfJoining = user.DateOfJoining,
                DateOfRelieving = user.DateOfRelieving,
                MobileNo = user.MobileNo,
                EmergencyNo = user.EmergencyNo,
                Active = user.Active,
                IsDeleted = user.IsDeleted,

                CreatedBy = user.CreatedBy,
                CreatedAt = user.CreatedAt,

                UpdatedBy = user.UpdatedBy,
                UpdatedAt = user.UpdatedAt,

                DeletedBy = user.DeletedBy,
                DeletedAt = user.DeletedAt,

                Role = new RoleDto
                {
                    RoleId = user.Role.RoleId,
                    RoleName = user.Role.RoleName
                },

                RefreshTokens = user.UserRefreshTokens.Select(rt => new UserRefreshTokenDto
                {
                    RefreshToken = rt.RefreshToken,
                    ExpiryDate = rt.ExpiryDate,
                    IsRevoked = rt.IsRevoked
                }).ToList()
            };

            return userDto;
        }

    }
}
