using mmmPizza.MoreJeeps.Mappers;

namespace mmmPizza.MoreJeeps.Services;

public interface IGameService
{
    Task AddSightingAsync(SightingRequest sightingRequest);
    Task<Game> GetGameAsync();
    Task ClearGameAsync();
}

public sealed class GameService : IGameService
{
    private readonly IGameRepository _repository;

    public GameService(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task AddSightingAsync(SightingRequest sightingRequest)
    {
        GameEntity activeGame = await _repository.GetGameAsync();
        Sighting sighting = new()
        {
            Id = Guid.NewGuid(),
            GameId = activeGame.Id,
            Player = sightingRequest.Player,
            SightedOn = DateTime.UtcNow
        };

        SightingEntity sightingEntity = sighting.ToSightingEntity();
        await _repository.AddSightingAsync(sightingEntity);
    }

    public async Task<Game> GetGameAsync()
    {
        GameEntity gameEntity = await _repository.GetGameAsync();
        var sightings = await _repository.GetSightingsAsync(gameEntity.Id);
        Game game = gameEntity.ToGame();
        game.PlayerScores = sightings
                    .GroupBy(s => s.Player)
                    .Select(s => new
                    {
                        Player = s.Key,
                        Score = s.Count()
                    })
                    .ToDictionary(s => s.Player, s => s.Score);

        return game;
    }
    public async Task ClearGameAsync()
    {
        await _repository.ClearGameAsync();
    }
}