using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Errors;

public static class ProductTypeErrors
{
    private static readonly string Base = "ProductType";

    public static readonly Error NotFound = new(
        $"{Base}.NotFound", "The Product Type was not found");
}