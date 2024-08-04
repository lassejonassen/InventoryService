using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.StorageLocations.Commands.DeleteStorageLocation;

internal sealed class DeleteStorageLocationCommandHandler : ICommandHandler<DeleteStorageLocationCommand>
{
	private readonly IStorageLocationRepository _storageLocationRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteStorageLocationCommandHandler(IStorageLocationRepository storageLocationRepository, IUnitOfWork unitOfWork)
	{
		_storageLocationRepository = storageLocationRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(DeleteStorageLocationCommand command, CancellationToken cancellationToken)
	{
		var result = await _storageLocationRepository.DeleteStorageLocationAsync(command.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
