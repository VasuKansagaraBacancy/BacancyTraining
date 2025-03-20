using Medicare__.Models;

namespace Medicare__.Repositories
{
    public interface IUserRefreshTokenRepository
    {
        Task AddAsync(UserRefreshToken token);
        Task<UserRefreshToken> GetValidTokenAsync(Guid userId, string? refreshToken);
        Task<List<UserRefreshToken>> GetAllValidTokensByUserIdAsync(Guid userId);
        Task SaveChangesAsync();
    }
}