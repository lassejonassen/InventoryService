using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.ItemTypes.Queries.GetItemTypeById;

public sealed record GetProductTypeByIdQuery(Guid Id) : IQuery<ProductType>;
