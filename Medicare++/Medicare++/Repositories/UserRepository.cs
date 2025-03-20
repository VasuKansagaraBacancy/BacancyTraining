using Medicare__.DatabaseContext;
using Medicare__.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MedicareDbContext _context;

        public UserRepository(MedicareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.IgnoreQueryFilters().ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(User user)
        {
            user.IsDeleted = true;
            user.Active = false;
            user.DeletedAt = DateTime.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByIdWithoutFilterAsync(Guid userId)
        {
            return await _context.Users
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        // ✅ Permanently delete user from DB
        public async Task PermanentDeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Invalid UserId", nameof(userId));

            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.UserRefreshTokens)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }
       
    }
}
