using RealEstateApp.Shared.Models;
using Shared.Services;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;
using Server.Data;

namespace Server.Services;

public class ListingService : IListingService
{
    private readonly RealEstateDbContext _context;
    private readonly IDatabase _redisDb;
    private const string CacheKey = "AllListings";

    public ListingService(RealEstateDbContext context, IConnectionMultiplexer redis)
    {
        _context = context;
        _redisDb = redis.GetDatabase();
    }

    public async Task<List<Listing>> GetListingsAsync()
    {
        var cachedData = await _redisDb.StringGetAsync(CacheKey);
        if (cachedData.HasValue)
        {
            return JsonSerializer.Deserialize<List<Listing>>(cachedData);
        }

        var listings = await _context.Listings.ToListAsync();

        await _redisDb.StringSetAsync(CacheKey, JsonSerializer.Serialize(listings), TimeSpan.FromMinutes(5));

        return listings;
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

        await _redisDb.KeyDeleteAsync(CacheKey);

        return listing;
    }
}
