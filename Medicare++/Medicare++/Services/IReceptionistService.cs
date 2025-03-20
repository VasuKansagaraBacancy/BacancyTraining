using Medicare__.DTO;
using Medicare__.Models;

namespace Medicare__.Services
{
    public interface IReceptionistService
    {
        Task<IEnumerable<Receptionist>> GetAllReceptionistsAsync();
        Task<Receptionist> GetReceptionistByIdAsync(int id);
        Task<Receptionist> CreateReceptionistAsync(ReceptionistDTO receptionistDTO);
        Task<bool> UpdateReceptionistAsync(int ReceptionistId, ReceptionistDTO receptionistDTO);
        Task<bool> PermanentDeleteReceptionistAsync(int receptionistId);
        Task<bool> SoftDeleteReceptionistAsync(int receptionistId);
    }
}
