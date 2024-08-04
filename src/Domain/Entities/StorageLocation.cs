using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Entities;

public sealed record StorageLocation : Entity
{
	public required string Name { get; set; }
	public string? Description { get; set; }

	public required string Street { get; set; }
	public required string HouseNumber { get; set; }
	public required string ZipCode { get; set; }
	public required string City { get; set; }
	public required string Country { get; set; }
	public int? Capacity { get; set; }
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