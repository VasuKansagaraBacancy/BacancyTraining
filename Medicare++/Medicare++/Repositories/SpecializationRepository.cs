using Medicare__.DatabaseContext;
using Medicare__.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly MedicareDbContext _context;

        public SpecializationRepository(MedicareDbContext context)
        {
            _context = context;
        }
        public async Task<Specialization> GetByIdAsync(int id)
        {
            var query = _context.Specializations.AsQueryable();
            return await _context.Specializations.FirstOrDefaultAsync(s => s.SpecializationId == id);
        }


        public async Task<IEnumerable<object>> GetAllWithDoctorsAsync()
        {
            return await _context.Specializations
                .Include(s => s.Doctors)
                .Select(s => new
                {
                    s.SpecializationId,
                    s.SpecializationName,
                    Doctors = s.Doctors.Select(d => new
                    {
                        d.DoctorId,
                        d.UserId,
                        d.Qualification,
                        d.LicenseNumber
                    })
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<object>> GetByIdWithDoctorsAsync(int id)
        {
            return await _context.Specializations
                .Include(s => s.Doctors)
                .Where(s => s.SpecializationId == id)
                .Select(s => new
                {
                    s.SpecializationId,
                    s.SpecializationName,
                    Doctors = s.Doctors.Select(d => new
                    {
                        d.DoctorId,
                        d.UserId,
                        d.Qualification,
                        d.LicenseNumber
                    })
                })
                .ToListAsync();
        }

        public async Task<Specialization> CreateAsync(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            await _context.SaveChangesAsync();
            return specialization;
        }

        public async Task<bool> UpdateAsync(Specialization specialization)
        {
            _context.Specializations.Update(specialization);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            //var query = _context.Doctors.AsQueryable();

            //if (includeDeleted)
            //    query = query.IgnoreQueryFilters();

            return await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == doctorId);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var specialization = await GetByIdAsync(id);

            _context.Specializations.Remove(specialization);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AssignSpecializationAsync(int doctorId, int specializationId)
        {
            var doctor = await GetDoctorByIdAsync(doctorId);
            if (doctor == null) return false;

            var specialization = await GetByIdWithDoctorsAsync(specializationId);
            if (specialization == null) return false;

            doctor.SpecializationId = specializationId;
            //doctor.UpdatedAt = DateTime.UtcNow;
            // doctor.UpdatedBy = someUserId;

            await _context.SaveChangesAsync();
            return true;
        }

    }

}
