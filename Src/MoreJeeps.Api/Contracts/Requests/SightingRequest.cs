namespace MoreJeeps.Api.Contracts.Requests;

public class SightingRequest
{
    public string PlayerName { get; set; } = default!;
    public DateTime DateOfSighting { get; set; } = default!;
    public Single Longitude { get; set; } = default!;
    public Single Latitude { get; set; } = default!;
}