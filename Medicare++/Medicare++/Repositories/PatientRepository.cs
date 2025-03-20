using Medicare__.DatabaseContext;
using Medicare__.DTO;
using Medicare__.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Medicare__.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedicareDbContext _context;

        public PatientRepository(MedicareDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.PatientId == id);
        }
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients
                .Where(p => p.Active) // Only return active patients if needed
                .ToListAsync();
        }
        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task<bool> DeletePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> PermanentDeletePatientAsync(Patient patient)
        {
            _context.Patients.Remove(patient);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

    }

}
