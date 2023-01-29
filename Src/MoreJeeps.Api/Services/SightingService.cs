using MoreJeeps.Api.Repositories;

namespace MoreJeeps.Api.Services;

public sealed class SightingService : ISightingService
{
    private readonly ILogger<SightingService> _logger;
    private readonly ISightingRepository _sightingRepository;

    public SightingService(ILogger<SightingService> logger, ISightingRepository sightingRepository)
    {
        _logger = logger;
        _sightingRepository = sightingRepository;
    }

    public async Task<bool> CreateAsync(Sighting sighting)
    {
        var entity = sighting.ToSightingEntity();
        return await _sightingRepository.CreateAsync(entity);
    }

    public async Task<Sighting?> GetAsync(Guid id)
    {
        var entity = await _sightingRepository.GetAsync(id);

        if (entity is null)
        {
            return null;
        }

        var sighting = entity.ToSighting();

        return sighting;
    }

    public async Task<IEnumerable<Sighting>> GetAllAsync()
    {
        var entities = await _sightingRepository.GetAllAsync();
        var sightings = entities.Select(e => e.ToSighting());

        return sightings;
    }
}