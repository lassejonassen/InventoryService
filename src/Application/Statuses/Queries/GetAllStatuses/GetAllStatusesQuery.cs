namespace InventoryService.Application.Statuses.Queries.GetAllStatuses;

public sealed record GetAllStatusesQuery : IQuery<IEnumerable<Status>>;
