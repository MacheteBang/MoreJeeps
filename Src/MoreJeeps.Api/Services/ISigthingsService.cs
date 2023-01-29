namespace MoreJeeps.Api.Services;

public interface ISightingService
{
    Task<bool> CreateAsync(Sighting sighting);
    Task<Sighting?> GetAsync(Guid id);
    Task<IEnumerable<Sighting>> GetAllAsync();
}