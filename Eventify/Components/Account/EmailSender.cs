using Eventify.Data;
using Eventify.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Net.Http;

namespace Eventify.Components.Account
{
    public class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger, IHttpClientFactory httpClientFactory) : IEmailSender<ApplicationUser>
    {
        private readonly ILogger logger = logger;
        private readonly IHttpClientFactory _httpClient;

        public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email,
            string confirmationLink) => SendEmailAsync(email, "Confirm your email",
            $"Please confirm your account by " +
            "<a href='{confirmationLink}'>clicking here</a>.");

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

        public async Task<bool> Execute(string apiKey, string subject, string message,
            string toEmail)
        {

            var apiEmail = new
            {
                From = new { Email = Options.SenderEmail, Name = Options.SenderEmail },
                To = new[] { new { Email = toEmail, Name = toEmail } },
                Subject = subject,
                Text = message
            };


            var httpResponse = await _httpClient.CreateClient("MailTrapApiClient").PostAsJsonAsync("send", apiEmail);

            var responseJson = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson);

            if (response != null && response.TryGetValue("success", out object? success) && success is bool boolSuccess && boolSuccess)
            {
                return true;
            }

            return false;
        }
    }
}
