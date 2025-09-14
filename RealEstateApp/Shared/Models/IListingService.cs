using RealEstateApp.Shared.Models;

namespace Shared.Services;

public interface IListingService
{
    Task<List<Listing>> GetListingsAsync(); // return all listings
    Task<Listing?> GetListingsByIdAsync(int Id); // return listing by id while clicking the listing
    Task<Listing> AddListingAsync(ListingDTO listingDTO); // add listing

}