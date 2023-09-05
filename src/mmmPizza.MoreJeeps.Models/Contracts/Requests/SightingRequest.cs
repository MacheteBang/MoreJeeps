using System.Text.Json.Serialization;

namespace mmmPizza.MoreJeeps.Contracts.Requests;

public class SightingRequest
{
    [JsonPropertyName("player")] public Players Player { get; set; }
}