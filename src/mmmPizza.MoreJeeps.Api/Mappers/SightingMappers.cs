namespace mmmPizza.MoreJeeps.Mappers;

public static class SightingMappers
{
    public static SightingEntity ToSightingEntity(this Sighting model)
    {
        return new SightingEntity
        {
            Id = model.Id,
            GameId = model.GameId,
            Player = model.Player,
            SightedOn = model.SightedOn
        };
    }
}