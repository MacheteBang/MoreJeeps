using Azure;
using Azure.Data.Tables;

namespace mmmPizza.MoreJeeps.DataAccess.Entities;

public abstract class BaseTableEntity : ITableEntity
{
    public string PartitionKey { get; set; } = string.Empty;
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}