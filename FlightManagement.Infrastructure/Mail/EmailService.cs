using System.Threading.Tasks;
using FlightManagement.Application.Contracts.Infrastructure;
using FlightManagement.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FlightManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; set; }
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _logger = logger;
            _emailSettings = emailSettings.Value;
        }

        public Task<bool> SendEmail(Email email)
        {
            _logger.LogInformation($"Email sent to: {email.To} with subject {email.Subject}.");
            return Task.FromResult(true);
        }
    }
}