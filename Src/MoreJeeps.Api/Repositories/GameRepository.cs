using MoreJeeps.Api.Contracts.Data;
using MoreJeeps.Api.Database;

namespace MoreJeeps.Api.Repositories;

public sealed class GameRepository : IGameRepository
{

    private ILogger<GameRepository> _logger;
    private MoreJeepsContext _moreJeepsContext;


    public GameRepository(ILogger<GameRepository> logger, MoreJeepsContext moreJeepsContext)
    {
        _logger = logger;
        _moreJeepsContext = moreJeepsContext;
    }


    public async Task<bool> CreateAsync(GameEntity game)
    {
        _moreJeepsContext.Games.Add(game);
        var dbResult = await _moreJeepsContext.SaveChangesAsync();
        return dbResult == 1;
    }

    public async Task<GameEntity?> GetAsync(Guid id)
    {
        var entity = await _moreJeepsContext.Games.FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<GameEntity>> GetAllAsync()
    {
        var games = _moreJeepsContext.Games;
        return await Task.FromResult<IEnumerable<GameEntity>>(games);

    }
}