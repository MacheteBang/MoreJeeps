namespace mmmPizza.MoreJeeps.Functions;

public class SightingFunctions
{
    [FunctionName("AddSighting")]
    public async Task<IActionResult> AddSightingAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "sightings")] HttpRequest request)
    {
        string bodyAsString = await request.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(bodyAsString)) return new BadRequestObjectResult("Invalid sightings object sent");

        SightingRequest? sighting;
        try
        {
            sighting = JsonSerializer.Deserialize<SightingRequest>(bodyAsString);
            if (sighting is null) return new BadRequestObjectResult("Invalid sightings object sent");
        }
        catch (System.Exception)
        {
            return new BadRequestObjectResult("Invalid sightings object sent");
        }

        // TODO: Add service to add sighting

        return new OkResult();
    }
}