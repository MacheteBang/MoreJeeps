namespace mmmPizza.MoreJeeps.Contracts.Requests;

public class GameResponse
{
    [JsonPropertyName("scores")] public Dictionary<Players, int> Scores { get; set; } = new();
}