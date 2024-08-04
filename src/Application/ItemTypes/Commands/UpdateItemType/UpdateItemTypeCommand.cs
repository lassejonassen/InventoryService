using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.ItemTypes.Commands.UpdateItemType;

public sealed record UpdateItemTypeCommand(ItemType ItemType): ICommand;
