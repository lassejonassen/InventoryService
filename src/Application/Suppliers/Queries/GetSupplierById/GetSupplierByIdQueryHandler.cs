using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.Suppliers.Queries.GetSupplierById;

internal sealed class GetSupplierByIdQueryHandler : IQueryHandler<GetSupplierByIdQuery, Supplier>
{
	private readonly ISupplierRepository _repository;

	public GetSupplierByIdQueryHandler(ISupplierRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<Supplier>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<Supplier>(result.Error);
		}

		return result.Value;
	}
}
