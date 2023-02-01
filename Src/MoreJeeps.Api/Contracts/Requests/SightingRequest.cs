namespace MoreJeeps.Api.Contracts.Requests;

public class SightingRequest
{
    public string PlayerName { get; set; } = default!;
    public DateTimeOffset DateSightedUtc { get; set; } = default!;
    public Single Longitude { get; set; } = default!;
    public Single Latitude { get; set; } = default!;
    public Guid GameId { get; set; } = default!;
}