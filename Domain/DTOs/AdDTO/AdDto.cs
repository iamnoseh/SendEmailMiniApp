using Microsoft.AspNetCore.Http;

namespace Domain.DTOs.AdDTO;

public class AdDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    
    public IFormFile Media { get; set; }
}