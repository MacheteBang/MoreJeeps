namespace mmmPizza.MoreJeeps.Models;

public class Game
{
    public Dictionary<Players, int> PlayerScores { get; set; } = new();
}