using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> CreatePatientAsync(PatientDTO dto, string createdBy)
        {
            var random = new Random();
            int PatientId = random.Next(100000, 999999);
            var patient = new Patient
            {
                PatientId = PatientId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                AadharNo = dto.AadharNo,
                Address = dto.Address,
                City = dto.City,
                MobileNo = dto.MobileNo,
                Email = dto.Email,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow,
                Active = true
            };

            try
            {

                var createdPatient = await _repository.CreatePatientAsync(patient);
                return createdPatient;
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
        public async Task<Patient> UpdatePatientAsync(int id, PatientDTO dto, string updatedBy)
        {
            try
            {
                // Find the patient by Id
                var existingPatient = await _repository.GetPatientByIdAsync(id);
                if (existingPatient == null)
                    return null;

                // Update fields
                existingPatient.FirstName = dto.FirstName;
                existingPatient.LastName = dto.LastName;
                existingPatient.DateOfBirth = dto.DateOfBirth;
                existingPatient.Gender = dto.Gender;
                existingPatient.AadharNo = dto.AadharNo;
                existingPatient.Address = dto.Address;
                existingPatient.City = dto.City;
                existingPatient.MobileNo = dto.MobileNo;
                existingPatient.Email = dto.Email;

                // Set UpdatedBy and UpdatedAt
                existingPatient.UpdatedBy = updatedBy;
                existingPatient.UpdatedAt = DateTime.UtcNow;

                var updatedPatient = await _repository.UpdatePatientAsync(existingPatient);

                return updatedPatient;
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

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            try
            {
                var patients = await _repository.GetAllPatientsAsync();
                return patients;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unhandled Error in GetAllPatientsAsync: {ex.Message}");
            }
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            try
            {
                var patient = await _repository.GetPatientByIdAsync(id);
                return patient;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unhandled Error in GetPatientByIdAsync: {ex.Message}");
            }
        }

        public async Task<bool> SoftDeletePatientAsync(int patientId, string deletedBy)
        {
            var patient = await _repository.GetPatientByIdAsync(patientId);
            if (patient == null || patient.IsDeleted)
                return false;

            patient.IsDeleted = true;
            patient.Active = false;
            patient.UpdatedBy = deletedBy;
            patient.UpdatedAt = DateTime.UtcNow;

            return await _repository.DeletePatientAsync(patient);
        }

        public async Task<bool> PermanentDeletePatientAsync(int patientId)
        {
            var patient = await _repository.GetPatientByIdAsync(patientId);
            if (patient == null)
                return false;

            return await _repository.PermanentDeletePatientAsync(patient);
        }



    }
}
