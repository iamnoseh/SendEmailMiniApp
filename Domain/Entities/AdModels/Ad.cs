namespace Domain.Entities.AdModels;

public class Ad
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string MediaUrl { get; set; }
    public string Category { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime EndDate { get; set; }
}