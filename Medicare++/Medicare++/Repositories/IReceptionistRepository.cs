using Medicare__.DTO;
using Medicare__.Models;

namespace Medicare__.Repositories
{
    public interface IReceptionistRepository
    {
        Task<IEnumerable<Receptionist>> GetAllAsync();
        Task<Receptionist> GetByIdAsync(int id);
        Task SaveAsync();
        Task<bool> SoftDeleteReceptionistAsync(int ReceptionistId);
        Task<bool> PermanentDeleteReceptionistAsync(int ReceptionistId);
        Task<Receptionist> CreateReceptionistAsync(Receptionist receptionist);
        Task UpdateReceptionistAsync(Receptionist existingRceptionist);
    }

}
