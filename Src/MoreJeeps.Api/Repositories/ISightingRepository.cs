using MoreJeeps.Api.Contracts.Data;

namespace MoreJeeps.Api.Repositories;

public interface ISightingRepository
{
    Task<SightingEntity?> GetAsync(Guid id);
    Task<IEnumerable<SightingEntity>> GetAllAsync();
    Task<bool> CreateAsync(SightingEntity sighting);
}