namespace Medicare__.DTO
{
    public class AppointmentDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentStarts { get; set; }
        public DateTime AppointmentEnds { get; set; }
        public string Status { get; set; }
        public string AppointmentDescription { get; set; }
    }
}
