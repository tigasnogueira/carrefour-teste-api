using Carrefour.IdentityApi.Models;
using Carrefour.TransactionApi.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Carrefour.TransactionApi.Services;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;
    private readonly string _identityApiUrl;

    public IdentityService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _identityApiUrl = configuration["IdentityApiUrl"];
    }

    public async Task<UserToken> Register(UserRegister userRegister)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_identityApiUrl}/users/register", userRegister);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<UserToken>(responseBody, options);
    }

    public async Task<UserToken> Login(UserLogin userLogin)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_identityApiUrl}/users/login", userLogin);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<UserToken>(responseBody, options);
    }

    public async Task<UserClaim> GetClaims(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await _httpClient.GetAsync($"{_identityApiUrl}/users/claims");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<UserClaim>(responseBody, options);
    }
}

