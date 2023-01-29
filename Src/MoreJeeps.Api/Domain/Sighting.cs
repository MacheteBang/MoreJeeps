namespace MoreJeeps.Api.Domain;

public class Sighting
{
    public required Guid Id { get; init; } = Guid.NewGuid();
    public string PlayerName { get; set; } = default!;
    public DateTime DateOfSighting { get; set; } = default!;
    public Single Longitude { get; set; } = default!;
    public Single Latitude { get; set; } = default!;
    public Guid GameId { get; set; } = default!;
}