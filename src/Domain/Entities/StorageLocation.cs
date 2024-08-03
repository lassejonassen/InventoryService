using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Entities;

public sealed record StorageLocation : Entity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
}

public sealed record StorageLocationCreate
{
	public required string Name { get; init; }
	public string? Description { get; init; }
}

public static class StorageLocationErrors
{
	private static readonly string Base = "StorageLocation";

	public static readonly Error NotFound = new(
		$"{Base}.NotFound", "The Storage Location was not found");
}