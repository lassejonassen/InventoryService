namespace InventoryService.Domain.Primitives;

public abstract record Entity
{
    public required Guid Id { get; set; }
    public required Guid CorrelationId { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
