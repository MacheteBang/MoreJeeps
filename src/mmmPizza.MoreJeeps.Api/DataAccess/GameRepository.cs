namespace mmmPizza.MoreJeeps.DataAccess;

public interface IGameRepository
{
    Task AddSightingAsync(Sighting sighting);
    Task<Game> GetGameAsync();
    Task ClearGameAsync();
}

public sealed class GameRepository : IGameRepository
{
    public List<Sighting> _sightings = new();

    public async Task AddSightingAsync(Sighting sighting)
    {
        await Task.CompletedTask;

        _sightings.Add(sighting);
    }

    public async Task<Game> GetGameAsync()
    {
        await Task.CompletedTask;

        var scores = _sightings
            .GroupBy(s => s.Player)
            .Select(s => new
            {
                Player = s.Key,
                Score = s.Count()
            })
            .ToDictionary(s => s.Player, s => s.Score);

        return new Game
        {
            PlayerScores = scores
        };
    }

    public async Task ClearGameAsync()
    {
        await Task.CompletedTask;

        _sightings.Clear();
    }

}