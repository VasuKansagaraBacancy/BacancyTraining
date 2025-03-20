using Medicare__.DTO;
using Medicare__.Models;

namespace Medicare__.Repositories
{
    public interface IAppointmentRepository
    {
        Task<AppointmentDetailsDto> GetByIdWithDetailsAsync(int appointmentId);
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<Appointment?> UpdateAsync(Appointment appointment);
        Task<IEnumerable<AppointmentDetailsDto>> GetAllWithDetailsAsync();

        Task DeleteAsync(Appointment appointment);
        Task<Appointment?> GetByIdAsync(int appointmentId);
    }

}
