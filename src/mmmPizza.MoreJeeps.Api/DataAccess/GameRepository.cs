using Azure.Data.Tables;
using Microsoft.Extensions.Options;

namespace mmmPizza.MoreJeeps.DataAccess;

public interface IGameRepository
{
    Task AddSightingAsync(SightingEntity sighting);
    Task<List<SightingEntity>> GetSightingsAsync(Guid gameId);
    Task<GameEntity> GetGameAsync();
    Task ClearGameAsync();
}

public sealed class GameRepository : IGameRepository
{
    private readonly TableClient _sightingsClient;
    private readonly TableClient _gamesClient;

    public GameRepository(IOptions<MoreJeepsTableSettings> settings)
    {
        _sightingsClient = new TableClient(settings.Value.ConnectionString, settings.Value.SightingsTableName);
        _gamesClient = new TableClient(settings.Value.ConnectionString, settings.Value.GamesTableName);
    }

    public async Task AddSightingAsync(SightingEntity sightingEntity)
    {
        _ = await _sightingsClient.AddEntityAsync(sightingEntity);
    }

    public async Task<List<SightingEntity>> GetSightingsAsync(Guid gameId)
    {
        await Task.CompletedTask;

        return _sightingsClient
            .Query<SightingEntity>(TableClient.CreateQueryFilter($"GameId eq {gameId}"))
            .ToList();
    }


    public async Task ClearGameAsync()
    {
        // Get entity that is currently active.
        GameEntity? activeGame = _gamesClient
            .Query<GameEntity>("IsActive eq true")
            .FirstOrDefault();

        if (activeGame != default)
        {
            activeGame.IsActive = false;
            _ = await _gamesClient.UpdateEntityAsync(activeGame, Azure.ETag.All, TableUpdateMode.Replace);
        }

        GameEntity newGame = new()
        {
            Id = Guid.NewGuid(),
            IsActive = true
        };

        _ = await _gamesClient.AddEntityAsync(newGame);
    }

    public async Task<GameEntity> GetGameAsync()
    {
        GameEntity? activeGame = _gamesClient
            .Query<GameEntity>("IsActive eq true")
            .FirstOrDefault();

        if (activeGame != default)
        {
            return activeGame;
        }


        GameEntity newGame = new()
        {
            Id = Guid.NewGuid(),
            IsActive = true
        };

        _ = await _gamesClient.AddEntityAsync(newGame);

        return newGame;
    }
}