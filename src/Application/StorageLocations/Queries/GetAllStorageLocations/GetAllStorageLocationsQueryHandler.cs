using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.StorageLocations.Queries.GetAllStorageLocations;

internal sealed class GetAllStorageLocationsQueryHandler : IQueryHandler<GetAllStorageLocationsQuery, IEnumerable<StorageLocation>>
{
	private readonly IStorageLocationRepository _storageLocationRepository;

	public GetAllStorageLocationsQueryHandler(IStorageLocationRepository storageLocationRepository)
	{
		_storageLocationRepository = storageLocationRepository;
	}

	public async Task<Result<IEnumerable<StorageLocation>>> Handle(GetAllStorageLocationsQuery request, CancellationToken cancellationToken)
	{
		var entities = await _storageLocationRepository.GetAllStorageLocationsAsync(cancellationToken);
		return entities;
	}
}
