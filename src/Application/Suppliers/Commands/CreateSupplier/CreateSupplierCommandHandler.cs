using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Errors;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.Suppliers.Commands.CreateSupplier;

internal sealed class CreateSupplierCommandHandler : ICommandHandler<CreateSupplierCommand, Guid>
{
	private readonly ISupplierRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateSupplierCommandHandler(ISupplierRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
	{

		if (!await _repository.IsNameUnique(command.Name, cancellationToken))
		{
			return Result.Failure<Guid>(SupplierErrors.SupplierAlreadyExists);
		}


		var supplier = new Supplier() {
			Id = Guid.NewGuid(),
			CorrelationId = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			Name = command.Name,
			Street = command.Street,
			City = command.City,
			State = command.State,
			PostalCode = command.PostalCode,
			Country = command.Country,
			Phone = command.Phone,
			Email = command.Email
		};

		await _repository.AddAsync(supplier, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return supplier.Id;
	}
}
