using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.StorageLocations.Commands.DeleteStorageLocation;

public sealed record DeleteStorageLocationCommand(Guid Id): ICommand;