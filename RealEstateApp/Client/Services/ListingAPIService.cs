using System.Net.Http.Json;
using RealEstateApp.Shared.Models;

namespace RealEstateApp.Client.Services;

public class ListingApiService
{
    private readonly HttpClient _http;

    public ListingApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Listing>> GetListingsAsync()
        => await _http.GetFromJsonAsync<List<Listing>>("api/listings");

    public async Task<Listing> AddListingAsync(ListingDTO listingDTO)
    {
        var response = await _http.PostAsJsonAsync("api/listings", listingDTO);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Listing>();
    }
}
