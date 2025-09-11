using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Shared.Models;

public class Listing
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please select a type.")]
    public string Type { get; set; }
    [Required]
    public string Place { get; set; }
    [Required]
    public double Area { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Description { get; set; }
}