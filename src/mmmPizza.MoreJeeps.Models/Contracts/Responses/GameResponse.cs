namespace mmmPizza.MoreJeeps.Contracts.Requests;

public class GameResponse
{
    [JsonPropertyName("playerScores")] public Dictionary<Players, int> PlayerScores { get; set; } = new();
}