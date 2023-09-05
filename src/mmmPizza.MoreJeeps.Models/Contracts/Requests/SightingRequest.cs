using System.Text.Json.Serialization;

namespace mmmPizza.MoreJeeps.Contracts.Requests;

public class SightingRequest
{
    [JsonPropertyName("player"), JsonConverter(typeof(JsonStringEnumConverter))]
    public Players Player { get; set; }
}