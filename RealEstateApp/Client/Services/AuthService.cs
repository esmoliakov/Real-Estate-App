using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.JSInterop;

namespace RealEstateApp.Client.Services;

public class AuthService
{
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();

    private readonly HttpClient _http;
    private readonly IJSRuntime _js;
    public bool IsAuthenticated { get; private set; }
    public string? Username { get; private set; }

    public AuthService(HttpClient http, IJSRuntime js)
    {
        _http = http;
        _js = js;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", new { username, password });
        if (response.IsSuccessStatusCode)
        {
            IsAuthenticated = true;
            Username = username;

            // Save to localStorage
            var userJson = JsonSerializer.Serialize(new { username });
            await _js.InvokeVoidAsync("localStorage.setItem", "authUser", userJson);

            NotifyStateChanged();
            return true;
        }
        return false;
    }

    public async Task<bool> RegisterAsync(string username, string password)
    {
        var response = await _http.PostAsJsonAsync("api/auth/register", new { username, password });
        return response.IsSuccessStatusCode;
    }

    public async Task LogoutAsync()
    {
        IsAuthenticated = false;
        Username = null;
        await _js.InvokeVoidAsync("localStorage.removeItem", "authUser");
        NotifyStateChanged();
    }

    // Call this on app startup to restore login state
    public async Task RestoreLoginAsync()
    {
        var json = await _js.InvokeAsync<string>("localStorage.getItem", "authUser");
        if (!string.IsNullOrEmpty(json))
        {
            var user = JsonSerializer.Deserialize<StoredUser>(json);
            if (user != null)
            {
                IsAuthenticated = true;
                Username = user.Username;
                NotifyStateChanged();
            }
        }
    }
    private class StoredUser
    {
        public string Username { get; set; } = string.Empty;
    }

}
