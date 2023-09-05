namespace mmmPizza.MoreJeeps.Services;

public interface IGameService
{
    Task AddSightingAsync(Sighting sighting);
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

    public async Task AddSightingAsync(Sighting sighting)
    {
        await _repository.AddSightingAsync(sighting);
    }

    public async Task<Game> GetGameAsync()
    {
        return await _repository.GetGameAsync();
    }
    public async Task ClearGameAsync()
    {
        await _repository.ClearGameAsync();
    }
}