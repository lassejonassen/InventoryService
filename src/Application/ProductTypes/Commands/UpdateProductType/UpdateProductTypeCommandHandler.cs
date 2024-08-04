using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Commands.UpdateItemType;

internal sealed class UpdateProductTypeCommandHandler : ICommandHandler<UpdateProductTypeCommand>
{
	private readonly IProductTypeRepository _repository;
	private readonly IUnitOfWork _unitOfOWork;

	public UpdateProductTypeCommandHandler(IProductTypeRepository repository, IUnitOfWork unitOfOWork)
	{
		_repository = repository;
		_unitOfOWork = unitOfOWork;
	}

	public async Task<Result> Handle(UpdateProductTypeCommand command, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateProductTypeAsync(command.ItemType, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfOWork.SaveChangesAsync(cancellationToken);
		return Result.Success();
	}
}
