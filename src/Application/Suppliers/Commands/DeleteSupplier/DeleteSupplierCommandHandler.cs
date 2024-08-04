using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.Suppliers.Commands.DeleteSupplier;

internal sealed class DeleteSupplierCommandHandler : ICommandHandler<DeleteSupplierCommand>
{
	private readonly ISupplierRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteSupplierCommandHandler(ISupplierRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(DeleteSupplierCommand command, CancellationToken cancellationToken)
	{
		var result = await _repository.DeleteAsync(command.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
