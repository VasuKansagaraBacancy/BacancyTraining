namespace Medicare__.DTO
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string SpecializationName { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
