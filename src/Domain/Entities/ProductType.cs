
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Entities;

public sealed record ProductType : Entity
{
	public required string Name { get; set; }
}


public static class ProductTypeErrors
{
	private static readonly string Base = "ProductType";

	public static readonly Error NotFound = new(
		$"{Base}.NotFound", "The Product Type was not found");
}