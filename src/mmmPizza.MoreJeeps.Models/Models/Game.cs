namespace mmmPizza.MoreJeeps.Models;

public class Game
{
    public Guid Id { get; set; }
    public Dictionary<Players, int> PlayerScores { get; set; } = new();
}