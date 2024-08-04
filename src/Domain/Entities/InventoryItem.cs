using InventoryService.Domain.Enums;

namespace InventoryService.Domain.Entities;

public sealed record InventoryItem : Entity
{
	public required Guid ProductId { get; set; }
	public required Product Product { get; set; }
	public required Guid StorageLocationId { get; set; }
	public required StorageLocation StorageLocation { get; set; }
	public required InventoryItemStatus Status { get; set; }
	public required string BatchNumber { get; set; }
	public DateTimeOffset? ExpiryDate { get; set; }
}
