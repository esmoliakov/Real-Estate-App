using System.ComponentModel.DataAnnotations;
namespace RealEstateApp.Shared.Models;

public class ListingDTO
{
    [Required(ErrorMessage = "Please select a property type.")]
    public string Type { get; set; } = string.Empty;

    [Required(ErrorMessage = "Area is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "Area must be greater than 0.")]
    public double Area { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Bedrooms count is required.")]
    [Range(1, 100, ErrorMessage = "Bedrooms must be at least 1.")]
    public int Bedrooms { get; set; }

    [Required(ErrorMessage = "Bathrooms count is required.")]
    [Range(1, 100, ErrorMessage = "Bathrooms must be at least 1.")]
    public int Bathrooms { get; set; }

    [Required(ErrorMessage = "Year built is required.")]
    [Range(1800, 2100, ErrorMessage = "Year built must be greater than 0.")]
    public int YearBuilt { get; set; }

    [Required(ErrorMessage = "Heating type is required.")]
    public string HeatingType { get; set; } = string.Empty;

    // Location
    [Required(ErrorMessage = "Country is required.")]
    public string Country { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "District is required.")]
    public string District { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Zip code is required.")]
    public string ZipCode { get; set; } = string.Empty;

    // Side info
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 2000 characters.")]
    public string Description { get; set; } = string.Empty;

    // Contacts
    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name and last name are required.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Name and last name must be between 1 and 200 characters.")]
    public string NameLastName { get; set; } = string.Empty;
}