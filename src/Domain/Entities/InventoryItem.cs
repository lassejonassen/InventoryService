using InventoryService.Domain.Primitives;

namespace InventoryService.Domain.Entities;

public sealed record InventoryItem : Entity
{
	public required Guid ProductId { get; set; }
	public required Guid StorageLocationId { get; set; }
	public required StorageLocation StorageLocation { get; set; }
	public required Guid StatusId { get; set; }
	public required Status Status { get; set; }
	public required string BatchNumber { get; set; }
	public DateTimeOffset? ExpiryDate { get; set; }
}