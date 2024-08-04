using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Suppliers.Commands.UpdateSupplier;

public sealed record UpdateSupplierCommand(Supplier Supplier) : ICommand;