
using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string? Description, string SKU, Guid ProductTypeId, Guid SupplierId) : ICommand<Guid>;
