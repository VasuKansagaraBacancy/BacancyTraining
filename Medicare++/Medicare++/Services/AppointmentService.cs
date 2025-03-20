using Medicare__.DTO;
using Medicare__.Models;
using Medicare__.Repositories;

namespace Medicare__.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IEmailServiceX _emailService;
        private readonly ISmsService _smsService;

        public AppointmentService(
            IAppointmentRepository repository,
            IEmailServiceX emailService,
            ISmsService smsService
            )
        {
            _repository = repository;
            _emailService = emailService;
            _smsService = smsService;
        }

        
        public async Task<Appointment> CreateAppointmentAsync(AppointmentDTO dto, string createdBy)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentStarts = dto.AppointmentStarts,
                AppointmentEnds = dto.AppointmentEnds,
                Status = dto.Status,
                AppointmentDescription = dto.AppointmentDescription,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repository.CreateAsync(appointment);

            await NotifyUsers(created, "Created");

            return created;
        }
        public async Task<bool> DeleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _repository.GetByIdAsync(appointmentId);

            if (appointment == null)
                return false;
            await NotifyUsers(appointment, "Cancelled");

            await _repository.DeleteAsync(appointment);
            return true;
        }

        private async Task NotifyUsers(Appointment appointment, string action)
        {
            var appointmentWithDetails = await _repository.GetByIdWithDetailsAsync(appointment.AppointmentId);

            var subject = $"MediCare+ - {action}";

            string body;
            string smsBody;

            if (action.Contains("Cancelled"))
            {
                body = $@"
    Dear {appointmentWithDetails.PatientName},

    We regret to inform you that your appointment has been cancelled as per your request or due to unforeseen circumstances.

    --------------------------------------
    🗓️  Original Appointment Date & Time:
            - Start: {appointment.AppointmentStarts:dddd, dd MMMM yyyy, hh:mm tt}
            - End: {appointment.AppointmentEnds:dddd, dd MMMM yyyy, hh:mm tt}

    👨‍⚕️  Consulting Doctor:
            - Dr. {appointmentWithDetails.DoctorName}

    📄  Status:
            - Cancelled
    --------------------------------------

    If you have any questions or would like to reschedule your appointment, please feel free to contact us at your earliest convenience.

    We apologize for any inconvenience this may have caused.

    Warm regards,  
    MediCare+ Team  
            ";

            smsBody = $"Hello {appointmentWithDetails.PatientName}, your appointment for {appointment.AppointmentStarts:dd MMM yyyy, hh:mm tt} with Dr. {appointmentWithDetails.DoctorName} has been cancelled. For assistance, contact MediCare+.";
            }
            else 
            {

                body = $@"
    Dear {appointmentWithDetails?.PatientName},

    We hope you are doing well.

    This is to inform you that your appointment has been successfully {action}. Kindly find your appointment details below:

    --------------------------------------
    🗓️  Appointment Date & Time:
            - Start: {appointment.AppointmentStarts:dddd, dd MMMM yyyy, hh:mm tt}
            - End: {appointment.AppointmentEnds:dddd, dd MMMM yyyy, hh:mm tt}

    👨‍⚕️  Consulting Doctor:
            - Dr. {appointmentWithDetails?.DoctorName}

    📄  Status:
            - {appointment.Status}

    📝  Description:
            - {appointment.AppointmentDescription}
    --------------------------------------

    If you have any questions or need assistance, please feel free to reach out to us.

    Thank you for choosing MediCare+ for your healthcare needs.  
    We look forward to assisting you!

    Warm regards,  
    MediCare+ Team  
                            ";


               smsBody = $"Hello {appointmentWithDetails?.PatientName}, your appointment has been {action} for {appointment.AppointmentStarts:dd MMM yyyy, hh:mm tt} with Dr. {appointmentWithDetails?.DoctorName}. - MediCare+";

            }

            if (appointmentWithDetails != null)
            {
                await _emailService.SendEmailAsync(appointmentWithDetails.PatientEmail, subject, body);
                await _smsService.SendSmsAsync(appointmentWithDetails.PatientPhoneNumber, smsBody);
            }
        }

        public async Task<Appointment?> UpdateAppointmentAsync(int appointmentId, AppointmentDTO dto, string updatedBy)
        {
            var appointmentToUpdate = new Appointment
            {
                AppointmentId = appointmentId,
                AppointmentStarts = dto.AppointmentStarts,
                AppointmentEnds = dto.AppointmentEnds,
                Status = "Updated",
                AppointmentDescription = dto.AppointmentDescription,
                UpdatedBy = updatedBy,
                UpdatedAt = DateTime.UtcNow
            };

            var updated = await _repository.UpdateAsync(appointmentToUpdate);

            if (updated == null)
                return null;

            await NotifyUsers(updated, "Updated");

            return updated;
        }

        public async Task<IEnumerable<AppointmentDetailsDto>> GetAllAppointmentsAsync()
        {
            return await _repository.GetAllWithDetailsAsync();
        }

        public async Task<AppointmentDetailsDto?> GetAppointmentDetailsByIdAsync(int appointmentId)
        {
            return await _repository.GetByIdWithDetailsAsync(appointmentId);
        }


    }
}
