namespace mmmPizza.MoreJeeps.Contracts.Requests;

public class GameResponse
{
    [JsonPropertyName("playerScores"), JsonConverter(typeof(JsonStringEnumConverter))]
    public Dictionary<Players, int> PlayerScores { get; set; } = new();
}