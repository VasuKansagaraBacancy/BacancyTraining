using Medicare__.DatabaseContext;
using Medicare__.DTO;
using Medicare__.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicare__.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MedicareDbContext _context;

        public AppointmentRepository(MedicareDbContext context)
        {
            _context = context;
        }


        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<AppointmentDetailsDto?> GetByIdWithDetailsAsync(int appointmentId)
        {
            return await _context.Appointments
                .Where(a => a.AppointmentId == appointmentId)
                .Select(a => new AppointmentDetailsDto
                {
                    AppointmentStarts = a.AppointmentStarts,
                    AppointmentEnds = a.AppointmentEnds,
                    PatientEmail = a.Patient.Email,
                    PatientPhoneNumber = a.Patient.MobileNo,
                    PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}",
                    DoctorName=$"{a.Doctor.User.FirstName} {a.Doctor.User.LastName}"
                })
                .FirstOrDefaultAsync();
        }
        public async Task<Appointment?> UpdateAsync(Appointment appointment)
        {
            var existing = await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId == appointment.AppointmentId);

            if (existing == null)
                return null;

            existing.AppointmentStarts = appointment.AppointmentStarts;
            existing.AppointmentEnds = appointment.AppointmentEnds;
            existing.Status = appointment.Status;
            existing.AppointmentDescription = appointment.AppointmentDescription;
            existing.UpdatedBy = appointment.UpdatedBy;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<IEnumerable<AppointmentDetailsDto>> GetAllWithDetailsAsync()
        {
            return await _context.Appointments
                .Select(a => new AppointmentDetailsDto
                {
                    AppointmentStarts = a.AppointmentStarts,
                    AppointmentEnds = a.AppointmentEnds,
                    PatientEmail = a.Patient.Email,
                    PatientPhoneNumber = a.Patient.MobileNo,
                    PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}",
                    DoctorName = $"{a.Doctor.User.FirstName} {a.Doctor.User.LastName}"
                }).ToListAsync();
        }
        public async Task DeleteAsync(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
        public async Task<Appointment?> GetByIdAsync(int appointmentId)
        {
            return await _context.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);
        }

    }
}
