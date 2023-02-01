namespace MoreJeeps.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Game ToGame(this GameRequest request)
    {
        return new Game
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
    }

    public static Sighting ToSighting(this SightingRequest request)
    {
        return new Sighting
        {
            Id = Guid.NewGuid(),
            PlayerName = request.PlayerName,
            DateSightedUtc = request.DateSightedUtc,
            Longitude = request.Longitude,
            Latitude = request.Latitude,
            GameId = request.GameId
        };
    }
}