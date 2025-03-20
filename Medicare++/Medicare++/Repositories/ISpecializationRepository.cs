using Medicare__.Models;

namespace Medicare__.Repositories
{
    public interface ISpecializationRepository
    {
        Task<Specialization> GetByIdAsync(int id);
        Task<IEnumerable<object>> GetAllWithDoctorsAsync();
        Task<IEnumerable<object>> GetByIdWithDoctorsAsync(int id);
        Task<Specialization> CreateAsync(Specialization specialization);
        Task<bool> UpdateAsync(Specialization specialization);
        Task<bool> DeleteAsync(int id);
        Task<bool> AssignSpecializationAsync(int doctorId, int specializationId);
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
    }

}
