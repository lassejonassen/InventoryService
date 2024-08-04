using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.ItemTypes.Queries.GetAllItemTypes;

public sealed record GetAllItemTypesQuery : IQuery<IEnumerable<ItemType>>;
