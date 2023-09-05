using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using mmmPizza.MoreJeeps.Contracts.Requests;
using mmmPizza.MoreJeeps.Models;
using mmmPizza.MoreJeeps.Web.Settings;

namespace mmmPizza.MoreJeeps.Web.Services;

public interface IMoreJeepsApiService
{
    Task IncrementScoreAsync(Players player);
    Task<Game> GetGameAsync();
    Task ResetGameAsync();
}

public sealed class MoreJeepsApiService : IMoreJeepsApiService
{
    private readonly HttpClient _httpClient;
    private readonly MoreJeepsApiSettings _settings;

    public MoreJeepsApiService(HttpClient httpClient, MoreJeepsApiSettings settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task IncrementScoreAsync(Players player)
    {
        string url = $"{_settings.BaseUrl}/sightings";
        SightingRequest sighting = new() { Player = player };
        _ = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(sighting), Encoding.UTF8, "application/json"));
    }

    public async Task<Game> GetGameAsync()
    {
        string url = $"{_settings.BaseUrl}/games";
        Game? game = await _httpClient.GetFromJsonAsync<Game>(url);
        if (game is not null) return game;

        return new Game { PlayerScores = new() };
    }

    public async Task ResetGameAsync()
    {
        string url = $"{_settings.BaseUrl}/games";
        _ = await _httpClient.DeleteAsync(url);
    }
}