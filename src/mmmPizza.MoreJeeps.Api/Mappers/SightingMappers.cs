namespace mmmPizza.MoreJeeps.Mappers;

public static class SightingMappers
{
    public static Sighting ToSighting(this SightingRequest request, DateTime sightedOn)
    {
        return new Sighting
        {
            Player = request.Player,
            SightedOn = sightedOn
        };
    }
}