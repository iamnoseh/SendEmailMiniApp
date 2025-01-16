namespace Domain.Entities.EmailDomains;

public class SMTPConfigurationModel
{
    //Adnin
    public string Email { get; set; } 
    public string Password { get; set; }
    public string Username { get; set; }
    
    //SMTP
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSSL { get; set; }
    public bool UseDefaultCredentials { get; set; }
    public bool IsBodyHtml { get; set; } 
}