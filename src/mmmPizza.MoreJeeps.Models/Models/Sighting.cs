namespace mmmPizza.MoreJeeps.Models;

public class Sighting
{
    public Guid Id { get; set; }
    public Guid GameId { get; set; }
    public Players Player { get; set; }
    public DateTime SightedOn { get; set; }
}