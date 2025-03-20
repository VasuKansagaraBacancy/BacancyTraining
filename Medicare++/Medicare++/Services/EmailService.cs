using System;
using System.Net;
using System.Net.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Medicare__.Models;
namespace Medicare__.Services
{
    public class EmailService
    {
        public void SendEmail(User user, string generatedPassword, string resetLink)
        {
            string subject = "Welcome to Medicare+ - Account Details";
            string body = $@"
            Hello {user.FirstName},

            Your account has been created. Your login details are:

            Email: {user.Email}
            Password: {generatedPassword}

            To change your password, click the link below:
            {resetLink}

            Regards,
            Admin Team
            ";

            MailMessage mail = new MailMessage("patelvasu7562@gmail.com", user.Email, subject, body);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("patelvasu7562@gmail.com", "aobfmcymldrpsabh"),
                EnableSsl = true
            };

            smtpClient.Send(mail);
        }
        public void SendResetPasswordEmail(User user, string resetLink)
        {
            string subject = "Reset Your Password";
            string body = $@"
        Hello {user.FirstName},

        Click the link below to reset your password:
        {resetLink}

        If you did not request this, please ignore this email.

        Regards,
        Admin Team
        ";

            SendMail(user.Email, subject, body);
        }
        private void SendMail(string toEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage("patelvasu7562@gmail.com", toEmail, subject, body);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("patelvasu7562@gmail.com", "aobfmcymldrpsabh"),
                EnableSsl = true
            };

            smtpClient.Send(mail);
        }
        public void SendPasswordChangedEmail(User user, string newPassword)
        {
            string subject = "Password Changed Successfully";
            string body = $@"
                            Hello {user.FirstName},

                            Your password has been successfully changed.

                            Username: {user.Email}
                            New Password: {newPassword}

                            If you did not request this change, please contact support immediately.

                            Regards,
                            Admin Team
                            ";

            SendMail(user.Email, subject, body);
        }

    }
}