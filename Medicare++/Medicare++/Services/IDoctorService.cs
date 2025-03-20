using Medicare__.DTO;
using Medicare__.Models;

namespace Medicare__.Services
{
    public interface IDoctorService
    {
        Task<Doctor> AddDoctorAsync(DoctorCreateDTO doctorDTO, string createdByUserId);
        Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
        Task<bool> UpdateDoctorAsync(int doctorId, DoctorUpdateDTO doctorDto);
        Task<bool> PermanentDeleteDoctorAsync(int doctorId);
        Task<bool> SoftDeleteDoctorAsync(int doctorId);
        

    }
}
