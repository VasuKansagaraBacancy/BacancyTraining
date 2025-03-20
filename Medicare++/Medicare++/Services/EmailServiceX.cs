using System.Net.Mail;
using System.Net;

namespace Medicare__.Services
{
    public class EmailServiceX : IEmailServiceX
    {
        private readonly IConfiguration _configuration;

        public EmailServiceX(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpHost = _configuration["EmailSettings:SmtpHost"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
                var smtpUser = _configuration["EmailSettings:SmtpUser"];
                var smtpPass = _configuration["EmailSettings:SmtpPass"];
                var fromEmail = _configuration["EmailSettings:FromEmail"];
                var displayName = _configuration["EmailSettings:DisplayName"];

                using (var client = new SmtpClient(smtpHost, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(fromEmail, displayName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false
                    };

                    mailMessage.To.Add(toEmail);

                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; // Re-throw so it can be caught by a higher-level handler if needed
            }
        }
    }
}
