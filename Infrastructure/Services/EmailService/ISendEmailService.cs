using Domain.Entities.EmailDomains;

namespace Infrastructure.Services.EmailService;

public interface ISendEmailService
{
    Task SendEmailAsync(UserEmailOption userEmailOption);
}