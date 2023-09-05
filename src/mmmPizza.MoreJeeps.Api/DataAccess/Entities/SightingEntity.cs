namespace mmmPizza.MoreJeeps.DataAccess;

public class SightingEntity : BaseTableEntity
{
    public Guid Id { get; set; }
    public Guid GameId { get; set; }
    public Players Player { get; set; }
    public DateTime SightedOn { get; set; }
}