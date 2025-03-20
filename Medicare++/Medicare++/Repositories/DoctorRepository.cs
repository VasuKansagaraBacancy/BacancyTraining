using Azure;
using Medicare__.DatabaseContext;
using Medicare__.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedicareDbContext _context;

        public DoctorRepository(MedicareDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Specialization)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Doctor?> GetDoctorByIdAsync(int doctorId)
        {
            return await _context.Doctors
                .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> SoftDeleteDoctorAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == doctorId && !d.IsDeleted);

            if (doctor == null)
                return false;

            doctor.IsDeleted = true;

            _context.Doctors.Update(doctor);
            return true;
        }

        public async Task<bool> PermanentDeleteDoctorAsync(int doctorId)
        {

            var doctor = await _context.Doctors.IgnoreQueryFilters().FirstOrDefaultAsync(d => d.DoctorId == doctorId);

            if (doctor == null)
                return false;

            if (!doctor.IsDeleted)
                return false;

            _context.Doctors.Remove(doctor);
            return true;
        }

    }
}
