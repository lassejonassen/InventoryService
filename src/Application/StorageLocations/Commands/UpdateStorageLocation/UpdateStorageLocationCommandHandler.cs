using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.StorageLocations.Commands.UpdateStorageLocation;

internal sealed class UpdateStorageLocationCommandHandler : ICommandHandler<UpdateStorageLocationCommand>
{
	private readonly IStorageLocationRepository _storageLocationRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateStorageLocationCommandHandler(IStorageLocationRepository storageLocationRepository, IUnitOfWork unitOfWork)
	{
		_storageLocationRepository = storageLocationRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateStorageLocationCommand command, CancellationToken cancellationToken)
	{
		var result = await _storageLocationRepository.UpdateStorageLocationAsync(command.StorageLocation, cancellationToken);
		
		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);
		return Result.Success();
	}
}