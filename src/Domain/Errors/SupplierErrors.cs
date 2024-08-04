using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Errors;

public static class SupplierErrors
{
	private static readonly string Base = "Supplier";

	public static readonly Error NotFound = new(
		$"{Base}.NotFound", "The Supplier was not found");

	public static readonly Error NotFoundByName = new(
		$"{Base}.NotFound", "The Supplier was not found by given name");
}
