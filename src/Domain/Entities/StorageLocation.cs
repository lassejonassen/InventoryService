using InventoryService.Domain.Primitives;

namespace InventoryService.Domain.Entities;

public sealed record StorageLocation : Entity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public int? Capacity { get; set; }
	public string? Street { get; set; }
	public string? City { get; set; }
	public string? Country { get; set; }
	public string? PostalCode { get; set; }
	public ICollection<InventoryItem>? Items { get; set; }
}