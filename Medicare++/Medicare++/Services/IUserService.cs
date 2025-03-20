using Medicare__.DTO;
using Medicare__.Model_DTO;

namespace Medicare__.Services
{
    public interface IUserService
    {
        Task<string> AddUserAsync(UserDto userDto, string adminId);
        Task<string> RequestPasswordResetAsync(string email);
        Task<string> ResetPasswordAsync(string token, string newPassword);
        Task<string> SoftDeleteUserAsync(Guid userId, string adminId);
        Task<string> PermanentDeleteUserAsync(Guid userId);
        Task<object> UpdateUserAsync(Guid userId, UserDto updatedUserDto, string adminId);
        Task<UserDetailDto> GetUserByIdAsync(Guid userId);

    }
}
