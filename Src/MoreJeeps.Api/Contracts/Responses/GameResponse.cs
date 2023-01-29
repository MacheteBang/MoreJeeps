namespace MoreJeeps.Api.Contracts.Responses;

public class GameResponse
{
    public required Guid Id { get; init; }
    public string Name { get; init; } = default!;
}