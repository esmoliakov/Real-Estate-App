using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Shared.Models;

public class Listing
{
    public int Id { get; set; }
    // Property info
    [Required(ErrorMessage = "Please select a type.")]
    public string Type { get; set; } = string.Empty;
    [Required]
    public double Area { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Bedrooms { get; set; }
    [Required]
    public int Bathrooms { get; set; }
    [Required]
    public int YearBuilt { get; set; }

    // Location
    [Required]
    public string Country { get; set; } = string.Empty;
    [Required]
    public string City { get; set; } = string.Empty;
    [Required]
    public string District { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public string ZipCode { get; set; } = string.Empty;

    // Side info
    [Required]
    public string Description { get; set; } = string.Empty;

    // Metadata
    public DateTime DateListed { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    // Contacts

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public string NameLastName { get; set; } = string.Empty;
}