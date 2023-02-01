namespace MoreJeeps.Api.Mapping;

public static class DomainToApiContractMapper
{
    public static GameResponse ToGameResponse(this Game game)
    {
        return new GameResponse
        {
            Id = game.Id,
            Name = game.Name,
            DateCreatedUtc = game.DateCreatedUtc
        };
    }

    public static SightingResponse ToSightingResponse(this Sighting sighting)
    {
        return new SightingResponse
        {
            Id = sighting.Id,
            PlayerName = sighting.PlayerName,
            DateSightedUtc = sighting.DateSightedUtc,
            Longitude = sighting.Longitude,
            Latitude = sighting.Latitude,
            GameId = sighting.GameId
        };
    }
}