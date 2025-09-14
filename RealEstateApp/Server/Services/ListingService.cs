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
            Place = listingDTO.Place,
            Description = listingDTO.Description,
            Price = listingDTO.Price
        };
        _listings.Add(listing);

        return Task.FromResult(listing);
    }
}