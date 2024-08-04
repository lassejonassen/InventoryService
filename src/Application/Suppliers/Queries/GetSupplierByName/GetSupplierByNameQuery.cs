using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Suppliers.Queries.GetSupplierByName;

public sealed record GetSupplierByNameQuery(string Name) : IQuery<Supplier>;