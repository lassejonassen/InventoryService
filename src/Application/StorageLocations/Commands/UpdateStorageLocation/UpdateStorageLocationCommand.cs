using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.StorageLocations.Commands.UpdateStorageLocation;

public sealed record UpdateStorageLocationCommand(StorageLocation StorageLocation) : ICommand;
