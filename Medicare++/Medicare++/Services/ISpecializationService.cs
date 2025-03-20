using Medicare__.Models;

namespace Medicare__.Services
{
    public interface ISpecializationService
    {
        Task<Specialization> GetSpecializationByIdAsync(int id);
        Task<IEnumerable<object>> GetAllSpecializationsAsync();
        Task<IEnumerable<object>> GetByIdWithDoctorsAsync(int id);
        Task<Specialization> CreateSpecializationAsync(string name, string createdBy);
        Task<bool> UpdateSpecializationAsync(int id, string name, string updatedBy);
        Task<bool> DeleteSpecializationAsync(int id);
        Task<bool> AssignSpecializationAsync(int doctorId, int specializationId);
    }

}
