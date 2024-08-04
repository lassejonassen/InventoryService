using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Queries.GetAllItemTypes;

internal sealed class GetAllItemTypesQueryHandler : IQueryHandler<GetAllItemTypesQuery, IEnumerable<ItemType>>
{
	private readonly IItemTypeRepository _repository;

	public GetAllItemTypesQueryHandler(IItemTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<ItemType>>> Handle(GetAllItemTypesQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetAllItemsAsync(cancellationToken);
	}
}
