namespace Medicare__.Services
{
    public interface IEmailServiceX
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
