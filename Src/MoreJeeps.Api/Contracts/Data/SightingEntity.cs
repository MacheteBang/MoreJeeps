using System.ComponentModel.DataAnnotations;

namespace MoreJeeps.Api.Contracts.Data;

public class SightingEntity
{
    public Guid Id { get; init; } = default!;
    public string PlayerName { get; set; } = default!;
    public DateTimeOffset DateSightedUtc { get; set; } = default!;
    public Single Longitude { get; set; } = default!;
    public Single Latitude { get; set; } = default!;

    public Guid GameId { get; set; } = default!;
    public GameEntity Game { get; set; } = default!;
}