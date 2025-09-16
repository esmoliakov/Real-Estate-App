using RealEstateApp.Shared.Models;
using Shared.Services;
using Microsoft.AspNetCore.Http;

namespace Server.Services;

class ListingService : IListingService
{
    private readonly List<Listing> _listings = new(); // in memory
    private int _nextId = 1;

    public Task<List<Listing>> GetListingsAsync()
    {
        return Task.FromResult(_listings);
    }

    public Task<Listing?> GetListingsByIdAsync(int id)
    {
        var listing = _listings.FirstOrDefault(l => l.Id == id);
        return Task.FromResult(listing);
    }

    public Task<Listing> AddListingAsync(ListingDTO listingDTO)
    {
        var listing = new Listing
        {
            Id = _nextId++,
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
            DateListed = listingDTO.DateListed,
            IsActive = listingDTO.IsActive,
            PhoneNumber = listingDTO.PhoneNumber,
            NameLastName = listingDTO.NameLastName
        };
        _listings.Add(listing);

        return Task.FromResult(listing);
    }
}