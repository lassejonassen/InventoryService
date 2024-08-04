using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.Suppliers.Commands.UpdateSupplier;

internal sealed class UpdateSupplierCommandHandler : ICommandHandler<UpdateSupplierCommand>
{
	private readonly ISupplierRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateSupplierCommandHandler(ISupplierRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateSupplierCommand command, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateAsync(command.Supplier, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
