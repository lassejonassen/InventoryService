using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Queries.GetItemTypeById;

internal sealed class GetProductTypeByIdQueryHandler : IQueryHandler<GetProductTypeByIdQuery, ProductType>
{
	private readonly IProductTypeRepository _repository;

	public GetProductTypeByIdQueryHandler(IProductTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<ProductType>> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _repository.GetProductTypeByIdAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<ProductType>(result.Error);
		}

		return result.Value;
	}
}
