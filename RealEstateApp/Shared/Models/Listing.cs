namespace Shared.Models;

public class Listing
{
    public int Id { get; set; }
    [required]
    public string Type { get; set; }
    [required]
    public string Place { get; set; }
    [required]
    public double Area { get; set; }
    [required]
    public decimal Price { get; set; }
    [required]
    public string Description { get; set; }
    [required]
    public Listing<string> ImageUrls { get; set; } = new();

    
    
}