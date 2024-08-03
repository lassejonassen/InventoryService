using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.StorageLocations.Commands.CreateStorageLocation;

public sealed record CreateStorageLocationCommand(string Name, string? Description) : ICommand<Guid>;