using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.Suppliers.Queries.GetSupplierByName;

internal sealed class GetSupplierByNameQueryHandler : IQueryHandler<GetSupplierByNameQuery, Supplier>
{
	private readonly ISupplierRepository _repository;

	public GetSupplierByNameQueryHandler(ISupplierRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<Supplier>> Handle(GetSupplierByNameQuery request, CancellationToken cancellationToken)
	{
		var result = await _repository.GetByNameAsync(request.Name, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<Supplier>(result.Error);
		}

		return result.Value;
	}
}
