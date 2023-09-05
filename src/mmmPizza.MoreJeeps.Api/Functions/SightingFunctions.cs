using mmmPizza.MoreJeeps.Mappers;

namespace mmmPizza.MoreJeeps.Functions;

public class SightingFunctions
{
    private readonly IGameService _gameService;

    public SightingFunctions(IGameService gameService)
    {
        _gameService = gameService;
    }

    [FunctionName("AddSighting")]
    public async Task<IActionResult> AddSightingAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "sightings")] HttpRequest request)
    {
        string bodyAsString = await request.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(bodyAsString)) return new BadRequestObjectResult("Invalid sightings object sent");

        SightingRequest? sightingRequest;
        try
        {
            sightingRequest = JsonSerializer.Deserialize<SightingRequest>(bodyAsString);
            if (sightingRequest is null) return new BadRequestObjectResult("Invalid sightings object sent");
        }
        catch (System.Exception)
        {
            return new BadRequestObjectResult("Invalid sightings object sent");
        }

        await _gameService.AddSightingAsync(sightingRequest.ToSighting(DateTime.UtcNow));

        return new OkResult();
    }
}