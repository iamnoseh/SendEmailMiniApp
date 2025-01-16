namespace Domain.DTOs.EmailDTO;

public class UpdateEmailSMTPConfigurationDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
}