namespace MoreJeeps.Api.Domain;

public class Game
{
    public required Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
}