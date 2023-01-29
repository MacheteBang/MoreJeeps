using MoreJeeps.Api.Contracts.Data;
using MoreJeeps.Api.Database;

namespace MoreJeeps.Api.Repositories;

public class SightingRepository : ISightingRepository
{

    private ILogger<SightingRepository> _logger;
    private MoreJeepsContext _moreJeepsContext;


    public SightingRepository(MoreJeepsContext moreJeepsContext, ILogger<SightingRepository> logger)
    {
        _logger = logger;
        _moreJeepsContext = moreJeepsContext;
    }


    public async Task<bool> CreateAsync(SightingEntity sighting)
    {
        _moreJeepsContext.Sightings.Add(sighting);
        var dbResult = await _moreJeepsContext.SaveChangesAsync();
        return dbResult == 1;
    }

    public async Task<SightingEntity?> GetAsync(Guid id)
    {
        var entity = await _moreJeepsContext.Sightings.FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<SightingEntity>> GetAllAsync()
    {
        var sightings = _moreJeepsContext.Sightings;
        return await Task.FromResult<IEnumerable<SightingEntity>>(sightings);
    }
}