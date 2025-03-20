namespace Medicare__.DTO
{
    public class DoctorCreateDTO
    {
        public Guid UserId { get; set; } 
        public int SpecializationId { get; set; }
        public string Qualification { get; set; } = string.Empty;
        public string? LicenseNumber { get; set; } 
    }
}
