namespace Medicare__.DTO
{
    public class AppointmentDetailsDto
    {
        public DateTime AppointmentStarts { get; set; }
        public DateTime AppointmentEnds { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhoneNumber { get; set; }
    }

}
