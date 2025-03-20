using Medicare__.DatabaseContext;
using Medicare__.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Repositories
{
    public class UserRefreshTokenRepository : IUserRefreshTokenRepository
    {
        private readonly MedicareDbContext _context;

        public UserRefreshTokenRepository(MedicareDbContext context) => _context = context;

        public async Task AddAsync(UserRefreshToken token) =>
            await _context.UserRefreshTokens.AddAsync(token);

        public Task<UserRefreshToken> GetValidTokenAsync(Guid userId, string refreshToken) =>
            _context.UserRefreshTokens
                .FirstOrDefaultAsync(t => t.UserId == userId && t.RefreshToken == refreshToken && !t.IsRevoked);

        public Task<List<UserRefreshToken>> GetAllValidTokensByUserIdAsync(Guid userId) =>
            _context.UserRefreshTokens
                .Where(t => t.UserId == userId && !t.IsRevoked)
                .ToListAsync();

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
