using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Commands.CreateItemType;

internal sealed class CreateItemTypeCommandHandler : ICommandHandler<CreateItemTypeCommand, Guid>
{
	private readonly IItemTypeRepository _repository;
	private readonly IUnitOfWork _unitOfOWork;

	public CreateItemTypeCommandHandler(IItemTypeRepository repository, IUnitOfWork unitOfOWork)
	{
		_repository = repository;
		_unitOfOWork = unitOfOWork;
	}

	public Task<Result<Guid>> Handle(CreateItemTypeCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
