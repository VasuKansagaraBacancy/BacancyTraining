using Medicare__.DTO;
using Medicare__.Model_DTO;
using Medicare__.Models;

namespace Medicare__.Services
{
    public interface IAuthService
    {
        Task<(string accessToken, string refreshToken)> LoginAsync(LoginRequestDTO request);
        Task<(string accessToken, string refreshToken)> RefreshTokenAsync(RefreshTokenRequestDTO request);
        Task LogoutAsync(Guid userId);
        Task<IEnumerable<User>> AllUsersAsync();
    }
}
