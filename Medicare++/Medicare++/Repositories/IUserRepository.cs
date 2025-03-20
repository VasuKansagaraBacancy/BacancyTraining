using Medicare__.Models;

namespace Medicare__.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task SoftDeleteAsync(User user);
        Task<User> GetByIdWithoutFilterAsync(Guid userId);
        Task PermanentDeleteAsync(User user);
        Task<User?> GetUserByIdAsync(Guid userId);

    }
}
