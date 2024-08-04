using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.ItemTypes.Commands.CreateItemType;

public sealed record CreateItemTypeCommand(string Name) : ICommand<Guid>;
