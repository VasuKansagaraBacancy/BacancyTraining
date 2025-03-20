namespace Medicare__.DTO
{
    public class DoctorUpdateDTO
    {
        public int SpecializationId { get; set; }
        public string Qualification { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
    }
}