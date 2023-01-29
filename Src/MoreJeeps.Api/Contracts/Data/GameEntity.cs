using System.ComponentModel.DataAnnotations;

namespace MoreJeeps.Api.Contracts.Data;

public class GameEntity
{
    public required Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;

    public IEnumerable<SightingEntity> SightingEntities {get; set; } = new List<SightingEntity>();
}