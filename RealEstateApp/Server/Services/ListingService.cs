using RealEstateApp.Shared.Models;
using Shared.Services;
using Microsoft.AspNetCore.Http;
using Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Server.Services;

public class ListingService : IListingService
{
    private readonly RealEstateDbContext _context;

    public ListingService(RealEstateDbContext context)
    {
        _context = context;
    }

    public async Task<List<Listing>> GetListingsAsync()
    {
        return await _context.Listings.ToListAsync();
    }

    public async Task<Listing?> GetListingsByIdAsync(int id)
    {
        return await _context.Listings.FindAsync(id);
    }

    public async Task<Listing> AddListingAsync(ListingDTO listingDTO)
    {
        var listing = new Listing
        {
            Type = listingDTO.Type,
            Area = listingDTO.Area,
            Price = listingDTO.Price,
            Bedrooms = listingDTO.Bedrooms,
            Bathrooms = listingDTO.Bathrooms,
            YearBuilt = listingDTO.YearBuilt,
            HeatingType = listingDTO.HeatingType,
            Country = listingDTO.Country,
            City = listingDTO.City,
            District = listingDTO.District,
            Address = listingDTO.Address,
            ZipCode = listingDTO.ZipCode,
            Description = listingDTO.Description,
            PhoneNumber = listingDTO.PhoneNumber,
            NameLastName = listingDTO.NameLastName,
            DateListed = DateTime.UtcNow,
            IsActive = true
        };

        _context.Listings.Add(listing);
        await _context.SaveChangesAsync();
        return listing;
    }
}