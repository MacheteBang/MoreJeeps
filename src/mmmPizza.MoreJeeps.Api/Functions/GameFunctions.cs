using mmmPizza.MoreJeeps.Mappers;

namespace mmmPizza.MoreJeeps.Functions;

public class GameFunctions
{
    private readonly IGameService _gameService;

    public GameFunctions(IGameService gameService)
    {
        _gameService = gameService;
    }

    [FunctionName("GetGame")]
    public async Task<IActionResult> GetGameAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "games")] HttpRequest request)
    {
        Game game = await _gameService.GetGameAsync();
        GameResponse gameResponse = game.ToGameResponse();

        return new OkObjectResult(gameResponse);
    }

    [FunctionName("ClearGame")]
    public async Task<IActionResult> ClearGameAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "games")] HttpRequest request)
    {
        await _gameService.ClearGameAsync();

        return new AcceptedResult();
    }
}