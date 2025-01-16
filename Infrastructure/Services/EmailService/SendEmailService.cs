using System.Net;
using System.Net.Mail;
using Domain.Entities.EmailDomains;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.EmailService;

public class SendEmailService : ISendEmailService
{
    private readonly SMTPConfigurationModel _smtpConfig;

    public SendEmailService(IOptions<SMTPConfigurationModel> smtpConfig)
    {
        _smtpConfig = smtpConfig.Value;
    }

    public async Task SendEmailAsync(UserEmailOption userEmailOption)
    {
        await SendEmail(userEmailOption);
    }
   
    
    public async Task SendEmail(UserEmailOption userEmailOption)
    {
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_smtpConfig.Email, _smtpConfig.Username);
                mail.Subject = userEmailOption.Subject;
                mail.To.Add(new MailAddress(userEmailOption.To));
                mail.Body = userEmailOption.Body;
                mail.IsBodyHtml = _smtpConfig.IsBodyHtml;

                using (SmtpClient smtpClient = new SmtpClient(_smtpConfig.Host, _smtpConfig.Port))
                {
                    NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.Email, _smtpConfig.Password);
                    smtpClient.Credentials = networkCredential;
                    smtpClient.EnableSsl = _smtpConfig.EnableSSL;
                    smtpClient.UseDefaultCredentials = _smtpConfig.UseDefaultCredentials;

                    await smtpClient.SendMailAsync(mail);
                }
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
}
