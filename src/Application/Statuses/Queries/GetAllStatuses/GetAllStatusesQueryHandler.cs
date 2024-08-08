namespace InventoryService.Application.Statuses.Queries.GetAllStatuses;

internal sealed class GetAllStatusesQueryHandler : IQueryHandler<GetAllStatusesQuery, IEnumerable<Status>>
{
	private readonly IStatusRepository _repository;

	public GetAllStatusesQueryHandler(IStatusRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<Status>>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(cancellationToken);
	}
}
