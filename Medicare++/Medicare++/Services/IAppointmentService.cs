using Medicare__.DTO;
using Medicare__.Models;

namespace Medicare__.Services
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointmentAsync(AppointmentDTO dto, string createdBy);
        Task<Appointment?> UpdateAppointmentAsync(int appointmentId, AppointmentDTO dto, string updatedBy);
        Task<IEnumerable<AppointmentDetailsDto>> GetAllAppointmentsAsync();
        Task<AppointmentDetailsDto?> GetAppointmentDetailsByIdAsync(int appointmentId);

        Task<bool> DeleteAppointmentAsync(int appointmentId);


    }
}
