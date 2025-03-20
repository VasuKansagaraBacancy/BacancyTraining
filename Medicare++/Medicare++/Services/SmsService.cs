using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Medicare__.Services
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;

            // Initialize Twilio client using credentials from appsettings.json
            TwilioClient.Init(
                _configuration["Twilio:AccountSid"],
                _configuration["Twilio:AuthToken"]
            );
        }

        public async Task SendSmsAsync(string toPhoneNumber, string message)
        {
            var fromPhoneNumber = _configuration["Twilio:FromPhoneNumber"];

            var messageResource = await MessageResource.CreateAsync(
                to: new PhoneNumber(toPhoneNumber),
                from: new PhoneNumber(fromPhoneNumber),
                body: message
            );
        }
    }
}
