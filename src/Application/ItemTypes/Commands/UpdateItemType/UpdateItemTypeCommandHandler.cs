using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Commands.UpdateItemType;

internal sealed class UpdateItemTypeCommandHandler : ICommandHandler<UpdateItemTypeCommand>
{
	private readonly IItemTypeRepository _repository;
	private readonly IUnitOfWork _unitOfOWork;

	public UpdateItemTypeCommandHandler(IItemTypeRepository repository, IUnitOfWork unitOfOWork)
	{
		_repository = repository;
		_unitOfOWork = unitOfOWork;
	}

	public async Task<Result> Handle(UpdateItemTypeCommand command, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateItemTypeAsync(command.ItemType, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfOWork.SaveChangesAsync(cancellationToken);
		return Result.Success();
	}
}
