using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Commands.DeleteItemType;

internal sealed class DeleteItemTypeCommandHandler : ICommandHandler<DeleteItemTypeCommand>
{
	private readonly IItemTypeRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteItemTypeCommandHandler(IItemTypeRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public Task<Result> Handle(DeleteItemTypeCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
