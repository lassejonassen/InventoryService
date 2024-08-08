using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Errors;

public static partial class DomainErrors
{
	public static class StorageLocation
	{
		private static readonly string Base = "StorageLocation";

		public static readonly Error NotFound = new(
			$"{Base}.NotFound", "The Storage Location was not found");
	}
}
