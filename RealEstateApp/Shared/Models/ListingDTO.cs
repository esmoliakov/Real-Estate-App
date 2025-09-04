using Microsoft.AspNetCore.Components.Forms;
namespace Shared.Models;

public class ListingDTO
{
    public string Type { get; set; }
    public string Place { get; set; }
    public double Area { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public List<IBrowserFile> Images { get; set; } = new();
}