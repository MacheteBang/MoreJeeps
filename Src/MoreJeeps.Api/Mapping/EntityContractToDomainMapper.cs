using MoreJeeps.Api.Contracts.Data;

namespace MoreJeeps.Api.Mapping;

public static class EntityContractToDomainMapper
{
    public static Game ToGame(this GameEntity entity)
    {
        return new Game
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public static Sighting ToSighting(this SightingEntity entity)
    {
        return new Sighting
        {
            Id = entity.Id,
            PlayerName = entity.PlayerName,
            DateOfSighting = entity.DateOfSighting,
            Longitude = entity.Longitude,
            Latitude = entity.Latitude,
            GameId = entity.GameId
        };
    }
}