namespace Shared.Models;

public class ListingDTO
{
    public string Type { get; set; }
    public string Place { get; set; }
    public double Area { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public ListingDTO<IFormFile> Images { get; set; } = new();
}