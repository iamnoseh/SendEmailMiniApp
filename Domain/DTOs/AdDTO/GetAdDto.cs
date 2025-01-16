namespace Domain.DTOs.AdDTO;

public class GetAdDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string MediaUrl { get; set; }
    public string Category { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime EndDate { get; set; }
}