using Medicare__.DatabaseContext;
using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Services
{
    public class ReceptionistService : IReceptionistService
    {
        private readonly IReceptionistRepository _repository;
        private readonly MedicareDbContext _context;

        public ReceptionistService(IReceptionistRepository repository, MedicareDbContext context)
        {
            _repository = repository;
            _context=context;
        }

        public async Task<IEnumerable<Receptionist>> GetAllReceptionistsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Receptionist> GetReceptionistByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Receptionist> CreateReceptionistAsync(ReceptionistDTO receptionistDTO)
        {
            if (string.IsNullOrWhiteSpace(receptionistDTO.Qualification))
                throw new ArgumentException("Qualification is required.");

            var userExists = await _context.Users.AnyAsync(u => u.UserId == receptionistDTO.UserId);
            if (!userExists)
                throw new ArgumentException($"User with Id {receptionistDTO.UserId} does not exist.");

            var alreadyReceptionist = await _context.Receptionists.AnyAsync(d => d.UserId == receptionistDTO.UserId);
            if (alreadyReceptionist)
                throw new ArgumentException($"UserId {receptionistDTO.UserId} is already assigned to a  Receptionist.");

            var random = new Random();
            int receptionistId = random.Next(100000, 999999);

            var receptionist = new Receptionist
            {
                ReceptionistId = receptionistId,
                UserId = receptionistDTO.UserId,
                Qualification = receptionistDTO.Qualification,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                var createdReceptionist = await _repository.CreateReceptionistAsync(receptionist);
                return createdReceptionist;
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message;
                throw new Exception($"Database Update Error: {innerMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unhandled Error: {ex.Message}");
            }

        }
        public async Task<bool> UpdateReceptionistAsync(int ReceptionistId, ReceptionistDTO receptionistDTO)
        {
            var existingRceptionist = await _repository.GetByIdAsync(ReceptionistId);

            if (existingRceptionist == null)
                return false;

            existingRceptionist.Qualification = receptionistDTO.Qualification;

            await _repository.UpdateReceptionistAsync(existingRceptionist);
            await _repository.SaveAsync();

            return true;
        }

        public async Task<bool> SoftDeleteReceptionistAsync(int receptionistId)
        {
            var result = await _repository.SoftDeleteReceptionistAsync(receptionistId);

            if (!result)
                return false;

            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> PermanentDeleteReceptionistAsync(int doctorId)
        {
            var result = await _repository.PermanentDeleteReceptionistAsync(doctorId);

            if (!result)
                return false;

            await _repository.SaveAsync();
            return true;
        }
    }

}
