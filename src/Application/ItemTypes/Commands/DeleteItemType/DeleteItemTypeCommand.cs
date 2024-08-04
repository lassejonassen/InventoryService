using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.ItemTypes.Commands.DeleteItemType;

public sealed record DeleteItemTypeCommand(Guid Id) : ICommand;
