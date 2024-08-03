using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.StorageLocations.Queries.GetAllStorageLocations;

public sealed record GetAllStorageLocationsQuery : IQuery<IEnumerable<StorageLocation>>;
