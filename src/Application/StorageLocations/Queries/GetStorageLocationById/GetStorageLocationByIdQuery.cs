using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.StorageLocations.Queries.GetStorageLocationById;

public sealed record GetStorageLocationByIdQuery(Guid Id) : IQuery<StorageLocation>;
