using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Commands.UpdateItemType;

internal sealed class UpdateItemTypeCommandHandler : ICommandHandler<UpdateItemTypeCommand>
{
	private readonly IItemTypeRepository _repository;
	private readonly IUnitOfWork _unitOfOWork;

	public Task<Result> Handle(UpdateItemTypeCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
