namespace MoreJeeps.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Sighting ToSighting(this SightingRequest request)
    {
        return new Sighting
        {
            Id = Guid.NewGuid(),
            PlayerName = request.PlayerName,
            DateOfSighting = request.DateOfSighting,
            Longitude = request.Longitude,
            Latitude = request.Latitude
        };
    }
}