using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.StorageLocations.Queries.GetStorageLocationById;

internal sealed class GetStorageLocationByIdQueryHandler : IQueryHandler<GetStorageLocationByIdQuery, StorageLocation>
{
	private readonly IStorageLocationRepository _repository;

	public GetStorageLocationByIdQueryHandler(IStorageLocationRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<StorageLocation>> Handle(GetStorageLocationByIdQuery query, CancellationToken cancellationToken)
	{
		var result = await _repository.GetStorageLocationByIdAsync(query.Id);

		if (result.IsFailure)
		{
			return Result.Failure<StorageLocation>(result.Error);
		}

		return result.Value;
	}
}
