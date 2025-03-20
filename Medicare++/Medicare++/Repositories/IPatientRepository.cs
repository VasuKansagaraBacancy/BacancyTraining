using Medicare__.DTO;
using Medicare__.Models;

namespace Medicare__.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> GetPatientByIdAsync(int id);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<bool> DeletePatientAsync(Patient patient);
        Task<bool> PermanentDeletePatientAsync(Patient patient);
    }
}
