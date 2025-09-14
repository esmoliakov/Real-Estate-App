namespace RealEstateApp.Shared.Models;

public class ListingDTO
{
    public string Type { get; set; }= string.Empty;
    public string Place { get; set; }= string.Empty;
    public double Area { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }= string.Empty;
}