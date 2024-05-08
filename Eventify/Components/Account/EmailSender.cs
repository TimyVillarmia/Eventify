using Eventify.Data;
using Eventify.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Net.Http;

namespace Eventify.Components.Account
{
    public class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger) : IEmailSender<ApplicationUser>
    {
        private readonly ILogger logger = logger;

        public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;



        public Task SendConfirmationLinkAsync(ApplicationUser user, string email,
            string confirmationLink) => SendEmailAsync(email, "Confirm your email",
            $"Please confirm your account by " +
            $"<a href='{confirmationLink}'>clicking here</a>.");

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email,
            string resetLink) => SendEmailAsync(email, "Reset your password",
            $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email,
            string resetCode) => SendEmailAsync(email, "Reset your password",
            $"Please reset your password using the following code: {resetCode}");

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.ApiToken))
            {
                throw new Exception("Null EmailAuthKey");
            }

            await Execute(Options.ApiToken, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message,
            string toEmail)
        {

            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(Options.SenderName, Options.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(toEmail, toEmail);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = subject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = message;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.Connect(Options.Server, Options.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        mailClient.Authenticate(Options.UserName, Options.Password);
                        mailClient.Send(emailMessage);
                        mailClient.Disconnect(true);
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
