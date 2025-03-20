using Medicare__.Models;
using Medicare__.Repositories;

namespace Medicare__.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;

        public SpecializationService(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<Specialization> GetSpecializationByIdAsync(int id)
        {
            return await _specializationRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<object>> GetAllSpecializationsAsync()
        {
            return await _specializationRepository.GetAllWithDoctorsAsync();
        }

        public async Task<IEnumerable<object>> GetByIdWithDoctorsAsync(int id)
        {
            return await _specializationRepository.GetByIdWithDoctorsAsync(id);
        }

        public async Task<Specialization> CreateSpecializationAsync(string name, string createdBy)
        {
            var specialization = new Specialization
            {
                SpecializationName = name,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow
            };

            return await _specializationRepository.CreateAsync(specialization);
        }

        public async Task<bool> UpdateSpecializationAsync(int id, string name, string updatedBy)
        {
            var specialization = await _specializationRepository.GetByIdAsync(id);
            if (specialization == null) return false;

            specialization.SpecializationName = name;
            specialization.UpdatedBy = updatedBy;
            specialization.UpdatedAt = DateTime.UtcNow;

            return await _specializationRepository.UpdateAsync(specialization);
        }

        public async Task<bool> DeleteSpecializationAsync(int id)
        {
            return await _specializationRepository.DeleteAsync(id);
        }
        public async Task<bool> AssignSpecializationAsync(int doctorId, int specializationId)
        {
            var doctor = await _specializationRepository.GetDoctorByIdAsync(doctorId);
            if (doctor == null)
                return false;

            var specialization = await _specializationRepository.GetByIdAsync(specializationId);
            if (specialization == null)
                return false;

            return await _specializationRepository.AssignSpecializationAsync(doctorId, specializationId);
        }

    }

}