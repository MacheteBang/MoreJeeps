namespace mmmPizza.MoreJeeps.Functions;

public class GameFunctions
{
    [FunctionName("GetGame")]
    public async Task<IActionResult> GetGameAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "games")] HttpRequest request)
    {
        // TODO: Add service to get game

        return new OkResult();
    }
}