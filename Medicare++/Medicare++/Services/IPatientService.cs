using Medicare__.DTO;
using Medicare__.Models;

namespace Medicare__.Services
{
    public interface IPatientService
    {
        Task<Patient> CreatePatientAsync(PatientDTO dto, string createdBy);
        Task<Patient> UpdatePatientAsync(int id, PatientDTO dto, string updatedBy);
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<bool> SoftDeletePatientAsync(int patientId, string deletedBy);
        Task<bool> PermanentDeletePatientAsync(int patientId);
    }
}
