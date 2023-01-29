using MoreJeeps.Api.Contracts.Data;

namespace MoreJeeps.Api.Mapping;

public static class DomainToEntityContractMapper
{
    public static GameEntity ToGameEntity(this Game game)
    {
        return new GameEntity
        {
            Id = game.Id,
            Name = game.Name
        };
    }

    public static SightingEntity ToSightingEntity(this Sighting sighting)
    {
        return new SightingEntity
        {
            Id = sighting.Id,
            PlayerName = sighting.PlayerName,
            DateOfSighting = sighting.DateOfSighting,
            Longitude = sighting.Longitude,
            Latitude = sighting.Latitude
        };
    }
}