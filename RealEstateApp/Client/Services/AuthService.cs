using System.Net.Http.Json;

namespace RealEstateApp.Client.Services;

public class AuthService
{
    private readonly HttpClient _http;
    public bool IsAuthenticated { get; private set; }
    public string? Username { get; private set; }

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", new { username, password });
        if (response.IsSuccessStatusCode)
        {
            IsAuthenticated = true;
            Username = username;
            return true;
        }
        return false;
    }

    public async Task<bool> RegisterAsync(string username, string password)
    {
        var response = await _http.PostAsJsonAsync("api/auth/register", new { username, password });
        return response.IsSuccessStatusCode;
    }

    public void Logout()
    {
        IsAuthenticated = false;
        Username = null;
    }
}
