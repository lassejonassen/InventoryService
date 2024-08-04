using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.ItemTypes.Commands.CreateItemType;

public sealed record CreateProductTypeCommand(string Name) : ICommand<Guid>;
