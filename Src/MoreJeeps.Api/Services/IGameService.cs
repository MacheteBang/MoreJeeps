namespace MoreJeeps.Api.Services;

public interface IGameService
{
    Task<bool> CreateAsync(Game game);
    Task<Game?> GetAsync(Guid id);
    Task<IEnumerable<Game>> GetAllAsync();
}