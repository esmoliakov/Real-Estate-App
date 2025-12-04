using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Shared.Models;

public class Listing
{
    public int Id { get; set; }
    // Property info
    [Required(ErrorMessage = "Please select a property type.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Type must be between 1 and 100 characters.")]
    public string Type { get; set; } = string.Empty;

    [Required(ErrorMessage = "Area is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "Area must be greater than 0.")]
    public double Area { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Bedrooms count is required.")]
    [Range(0, 100, ErrorMessage = "Bedrooms must be between 0 and 100.")]
    public int Bedrooms { get; set; }

    [Required(ErrorMessage = "Bathrooms count is required.")]
    [Range(0, 100, ErrorMessage = "Bathrooms must be between 0 and 100.")]
    public int Bathrooms { get; set; }

    [Required(ErrorMessage = "Year built is required.")]
    [Range(0, 2100, ErrorMessage = "Year built must be between 0 and 2100.")]
    public int YearBuilt { get; set; }

    [Required(ErrorMessage = "Heating type is required.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Heating type must be between 1 and 50 characters.")]
    public string HeatingType { get; set; } = string.Empty;

    // Location
    [Required(ErrorMessage = "Country is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Country must be between 1 and 100 characters.")]
    public string Country { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "City must be between 1 and 100 characters.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "District is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "District must be between 1 and 100 characters.")]
    public string District { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be between 1 and 200 characters.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Zip code is required.")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Zip code must be between 2 and 20 characters.")]
    public string ZipCode { get; set; } = string.Empty;

    // Side info
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 2000 characters.")]
    public string Description { get; set; } = string.Empty;

    // Metadata
    public DateTime DateListed { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    // Contacts
    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name and last name are required.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Name and last name must be between 1 and 200 characters.")]
    public string NameLastName { get; set; } = string.Empty;
}