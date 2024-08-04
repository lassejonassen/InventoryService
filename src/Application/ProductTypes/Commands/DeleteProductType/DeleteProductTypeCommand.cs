using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.ItemTypes.Commands.DeleteItemType;

public sealed record DeleteProductTypeCommand(Guid Id) : ICommand;
