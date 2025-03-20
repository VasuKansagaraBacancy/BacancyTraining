namespace Medicare__.Services
{
    public interface IReportService
    {
        Task<byte[]> GenerateUsersPdfAsync();
    }
}
