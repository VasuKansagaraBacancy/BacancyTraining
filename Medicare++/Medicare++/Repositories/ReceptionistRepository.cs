using Medicare__.DatabaseContext;
using Medicare__.DTO;
using Medicare__.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Repositories
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly MedicareDbContext _context;

        public ReceptionistRepository(MedicareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _context.Receptionists
                .ToListAsync();
        }

        public async Task<Receptionist?> GetByIdAsync(int id)
        {
            return await _context.Receptionists
                .FirstOrDefaultAsync(r => r.ReceptionistId == id);
        }

        public async Task<Receptionist> CreateReceptionistAsync(Receptionist receptionist)
        {
            await _context.Receptionists.AddAsync(receptionist);
            await _context.SaveChangesAsync();
            return receptionist;
        }

        public async Task UpdateReceptionistAsync(Receptionist receptionist)
        {
            _context.Receptionists.Update(receptionist);
            await Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteReceptionistAsync(int ReceptionistId)
        {
            var receptionist = await _context.Receptionists.FirstOrDefaultAsync(d => d.ReceptionistId == ReceptionistId && !d.IsDeleted);

            if (receptionist == null)
                return false;

            receptionist.IsDeleted = true;

            _context.Receptionists.Update(receptionist);
            return true;
        }

        public async Task<bool> PermanentDeleteReceptionistAsync(int ReceptionistId)
        {

            var receptionist = await _context.Receptionists.IgnoreQueryFilters().FirstOrDefaultAsync(d => d.ReceptionistId == ReceptionistId);

            if (receptionist == null)
                return false;

            if (!receptionist.IsDeleted)
                return false;

            _context.Receptionists.Remove(receptionist);
            return true;
        }
    }

}