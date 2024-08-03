using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.StorageLocations.Commands.CreateStorageLocation;

internal sealed class CreateStorageLocationCommandHandler : ICommandHandler<CreateStorageLocationCommand, Guid>
{
	private readonly IStorageLocationRepository _storageLocationRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateStorageLocationCommandHandler(
		IStorageLocationRepository storageLocationRepository, 
		IUnitOfWork unitOfWork)
	{
		_storageLocationRepository = storageLocationRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateStorageLocationCommand command, CancellationToken cancellationToken)
	{
		var storageLocation = new StorageLocation {
			Id = Guid.NewGuid(),
			CorrelationId = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			Name= command.Name,
			Description = command.Description
		};

		await _storageLocationRepository.CreateStorageLocationAsync(storageLocation, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return storageLocation.Id;
	}
}
