namespace MoreJeeps.Api.Mapping;

public static class DomainToApiContractMapper
{
    public static SightingResponse ToSightingResponse(this Sighting sighting)
    {
        return new SightingResponse
        {
            Id = sighting.Id,
            PlayerName = sighting.PlayerName,
            DateOfSighting = sighting.DateOfSighting,
            Longitude = sighting.Longitude,
            Latitude = sighting.Latitude
        };
    }
}