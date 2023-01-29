using Microsoft.AspNetCore.Mvc;

namespace MoreJeeps.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SightingsController : ControllerBase
{
    private readonly ILogger<SightingsController> _logger;
    private readonly ISightingService _sightingService;

    public SightingsController(ILogger<SightingsController> logger, ISightingService sightingService)
    {
        _logger = logger;
        _sightingService = sightingService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SightingRequest request)
    {
        var sighting = request.ToSighting();

        await _sightingService.CreateAsync(sighting);

        var sightingResposne = sighting.ToSightingResponse();

        return CreatedAtAction("Get", new { sightingResposne.Id }, sightingResposne);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var sighting = await _sightingService.GetAsync(id);

        if (sighting is null)
        {
            return NotFound();
        }

        var sightingResponse = sighting.ToSightingResponse();
        return Ok(sightingResponse);
    }
}
