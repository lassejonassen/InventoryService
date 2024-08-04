using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Queries.GetItemTypeById;

internal sealed class GetItemTypeByIdQueryHandler : IQueryHandler<GetItemTypeByIdQuery, ItemType>
{
	private readonly IItemTypeRepository _repository;

	public GetItemTypeByIdQueryHandler(IItemTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<ItemType>> Handle(GetItemTypeByIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _repository.GetItemByIdAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<ItemType>(result.Error);
		}

		return result.Value;
	}
}
