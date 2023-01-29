using MoreJeeps.Api.Contracts.Data;

namespace MoreJeeps.Api.Repositories;

public interface IGameRepository
{
    Task<GameEntity?> GetAsync(Guid id);
    Task<IEnumerable<GameEntity>> GetAllAsync();
    Task<bool> CreateAsync(GameEntity game);
}