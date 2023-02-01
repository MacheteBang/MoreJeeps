namespace MoreJeeps.Api.Contracts.Responses;

public class SightingResponse
{
    public required Guid Id { get; init; }
    public string PlayerName { get; set; } = default!;
    public DateTimeOffset DateSightedUtc { get; set; } = default!;
    public Single Longitude { get; set; } = default!;
    public Single Latitude { get; set; } = default!;
    public Guid GameId { get; set; } = default!;
}