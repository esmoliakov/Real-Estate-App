namespace RealEstateApp.Shared.Models;

public class ListingDTO
{
    // basic info
    public string Type { get; set; } = string.Empty;
    public double Area { get; set; }
    public decimal Price { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int YearBuilt { get; set; }
    public string HeatingType { get; set; } = string.Empty;

    // Location
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    // Side info
    public string Description { get; set; } = string.Empty;

    // Metadata
    public DateTime DateListed { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    // Contacts

    public string PhoneNumber { get; set; } = string.Empty;
    public string NameLastName { get; set; } = string.Empty;
}