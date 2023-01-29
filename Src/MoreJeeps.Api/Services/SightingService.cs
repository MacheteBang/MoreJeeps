namespace MoreJeeps.Api.Services;


public sealed class SightingService : ISightingService
{

    private ILogger<SightingService> _logger;

    public SightingService(ILogger<SightingService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> CreateAsync(Sighting sighting)
    {
        // TODO: Do something with the data
        return await Task.FromResult(true);
    }

    public async Task<Sighting?> GetAsync(Guid id)
    {
        // TODO: Get the data from somewhere
        return await Task.FromResult<Sighting>(new Sighting { Id = Guid.NewGuid() });
    }
}