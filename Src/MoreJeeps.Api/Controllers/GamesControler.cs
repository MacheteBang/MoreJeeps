using Microsoft.AspNetCore.Mvc;

namespace MoreJeeps.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly ILogger<GamesController> _logger;
    private readonly IGameService _gameService;

    public GamesController(ILogger<GamesController> logger, IGameService gameService)
    {
        _logger = logger;
        _gameService = gameService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GameRequest request)
    {
        var game = request.ToGame();

        await _gameService.CreateAsync(game);

        var gameResponse = game.ToGameResponse();

        return CreatedAtAction("Get", new { gameResponse.Id }, gameResponse);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var game = await _gameService.GetAsync(id);

        if (game is null)
        {
            return NotFound();
        }

        var gameResponse = game.ToGameResponse();
        return Ok(gameResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var games = await _gameService.GetAllAsync();
        var responses = games.Select(g => g.ToGameResponse());

        return Ok(responses);
    }
}
