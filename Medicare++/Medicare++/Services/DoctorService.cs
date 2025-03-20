using Medicare__.DatabaseContext;
using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly MedicareDbContext _context;
        public DoctorService(IDoctorRepository doctorRepository, MedicareDbContext context)
        {
            _doctorRepository = doctorRepository;
            _context = context;
        }

        public async Task<Doctor> AddDoctorAsync(DoctorCreateDTO doctorDTO, string createdByUserId)
        {
            if (string.IsNullOrWhiteSpace(doctorDTO.Qualification))
                throw new ArgumentException("Qualification is required.");

            var userExists = await _context.Users.AnyAsync(u => u.UserId == doctorDTO.UserId);
            if (!userExists)
                throw new ArgumentException($"User with Id {doctorDTO.UserId} does not exist.");

            var specializationExists = await _context.Specializations.AnyAsync(s => s.SpecializationId == doctorDTO.SpecializationId);
            if (!specializationExists)
                throw new ArgumentException($"Specialization with Id {doctorDTO.SpecializationId} does not exist.");

            var alreadyDoctor = await _context.Doctors.AnyAsync(d => d.UserId == doctorDTO.UserId && !d.IsDeleted);
            if (alreadyDoctor)
                throw new ArgumentException($"UserId {doctorDTO.UserId} is already assigned to a doctor.");

            var random = new Random();
            int doctorId = random.Next(100000, 999999);

            var doctor = new Doctor
            {
                DoctorId = doctorId,
                UserId = doctorDTO.UserId,
                SpecializationId = doctorDTO.SpecializationId,
                Qualification = doctorDTO.Qualification,
                LicenseNumber = doctorDTO.LicenseNumber,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = createdByUserId
            };

            try
            {
                var createdDoctor = await _doctorRepository.AddDoctorAsync(doctor);
                return createdDoctor;
            }
            catch (DbUpdateException ex)
            {
                // This shows the real SQL error
                var innerMessage = ex.InnerException?.Message;
                throw new Exception($"Database Update Error: {innerMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unhandled Error: {ex.Message}");
            }

        }
        public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();

            if (doctors == null || !doctors.Any())
            {
                return Enumerable.Empty<DoctorDTO>();
            }

            var doctorDTOs = doctors.Select(d => new DoctorDTO
            {
                DoctorId = d.DoctorId,
                UserId = d.UserId,
                FullName = $"{d.User?.FirstName} {d.User?.LastName}",
                SpecializationName = d.Specialization?.SpecializationName ?? "N/A",
                Qualification = d.Qualification,
                LicenseNumber = d.LicenseNumber,
                CreatedAt = d.CreatedAt
            });

            return doctorDTOs;
        }
        public async Task<bool> UpdateDoctorAsync(int doctorId, DoctorUpdateDTO doctorDto)
        {
            var existingDoctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);

            if (existingDoctor == null)
                return false;

            existingDoctor.SpecializationId = doctorDto.SpecializationId;
            existingDoctor.Qualification = doctorDto.Qualification;
            existingDoctor.LicenseNumber = doctorDto.LicenseNumber;

            await _doctorRepository.UpdateDoctorAsync(existingDoctor);
            await _doctorRepository.SaveAsync();

            return true;
        }
        public async Task<bool> SoftDeleteDoctorAsync(int doctorId)
        {
            var result = await _doctorRepository.SoftDeleteDoctorAsync(doctorId);

            if (!result)
                return false;

            await _doctorRepository.SaveAsync();
            return true;
        }

        public async Task<bool> PermanentDeleteDoctorAsync(int doctorId)
        {
            var result = await _doctorRepository.PermanentDeleteDoctorAsync(doctorId);

            if (!result)
                return false;

            await _doctorRepository.SaveAsync();
            return true;
        }
    }
}