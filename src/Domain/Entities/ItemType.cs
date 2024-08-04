
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Entities;

public sealed record ItemType : Entity
{
	public required string Name { get; set; }
}


public static class ItemTypeErrors
{
	private static readonly string Base = "ItemType";

	public static readonly Error NotFound = new(
		$"{Base}.NotFound", "The Item Type was not found");
}