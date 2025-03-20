using Medicare__.Models;

namespace Medicare__.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(int doctorId);
        Task UpdateDoctorAsync(Doctor doctor);
        Task SaveAsync();
        Task<bool> SoftDeleteDoctorAsync(int doctorId);
        Task<bool> PermanentDeleteDoctorAsync(int doctorId);

    }
}
