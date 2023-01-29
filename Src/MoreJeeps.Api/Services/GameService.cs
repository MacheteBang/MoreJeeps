using MoreJeeps.Api.Repositories;

namespace MoreJeeps.Api.Services;

public sealed class GameService : IGameService
{
    private readonly ILogger<GameService> _logger;
    private readonly IGameRepository _gameRepository;


    public GameService(ILogger<GameService> logger, IGameRepository gameRepository)
    {
        _logger = logger;
        _gameRepository = gameRepository;
    }


    public async Task<bool> CreateAsync(Game game)
    {
        var entity = game.ToGameEntity();
        return await _gameRepository.CreateAsync(entity);
    }

    public async Task<Game?> GetAsync(Guid id)
    {
        var entity = await _gameRepository.GetAsync(id);

        if (entity is null)
        {
            return null;
        }

        var game = entity.ToGame();

        return game;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        var entitites = await _gameRepository.GetAllAsync();
        var games = entitites.Select(e => e.ToGame());

        return games;
    }
}