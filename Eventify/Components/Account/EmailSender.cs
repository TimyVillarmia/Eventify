using Azure;
using Azure.Communication.Email;
using Eventify.Data;
using Eventify.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Cms;
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
            if (string.IsNullOrEmpty(Options.COMMUNICATION_SERVICES_CONNECTION_STRING))
            {
                throw new Exception("Null EmailAuthKey");
            }

            await Execute(Options.COMMUNICATION_SERVICES_CONNECTION_STRING, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message,
            string toEmail)
        {
            EmailClient emailClient = new EmailClient(apiKey);


            try
            {
                EmailSendOperation emailSendOperation = await emailClient.SendAsync(
                    Azure.WaitUntil.Completed,
                    "DoNotReply@b351b59a-c5ae-4b0b-a47a-4c4707db09d7.azurecomm.net",
                    toEmail,
                    subject,
                    message);
                EmailSendResult statusMonitor = emailSendOperation.Value;

                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
            }
            catch (RequestFailedException ex)
            {
                /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            }


        }
    }
}
