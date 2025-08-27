using System.Text.Json;
using BuilderCatalogueChallenge.Models;
using BuilderCatalogueChallenge.Models.SetModels;
using BuilderCatalogueChallenge.Models.UserModels;

namespace BuilderCatalogueChallenge.Services;

public class ApiClient
{
    private readonly HttpClient _client;
    public ApiClient(string baseUrl)
    {
        _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
    }
    
    public async Task<string> GetUserIdByUsernameAsync(string username)
    {
        var response = await _client.GetStringAsync($"/api/user/by-username/{username}");
        var user = JsonSerializer.Deserialize<User>(response);
        return user?.Id ?? throw new Exception("User not found");
    }

    public async Task<User> GetUserByUserId(string id)
    {
        var response = await _client.GetStringAsync($"/api/user/by-id/{id}");
        var user = JsonSerializer.Deserialize<User>(response);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }

    public async Task<List<SetSummary>> GetAllSetsAsync()
    { 
        var response = await _client.GetStringAsync("/api/sets");
        var setsResponse = JsonSerializer.Deserialize<AllSetsResponse>(response);
        var sets = setsResponse?.Sets ?? new List<SetSummary>();
        return sets;
    }
    
    public async Task<Set> GetSetByIdAsync(string id)
    {
        var response = await _client.GetStringAsync($"/api/set/by-id/{id}");
        var set = JsonSerializer.Deserialize<Set>(response);
        if (set == null)
        {
            throw new Exception("Set not found");
        }
        return set;
    }
}