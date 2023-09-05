namespace mmmPizza.MoreJeeps.DataAccess;

public class GameEntity : BaseTableEntity
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
}