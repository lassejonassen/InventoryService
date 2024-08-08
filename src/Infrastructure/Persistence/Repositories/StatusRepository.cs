using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public sealed class StatusRepository : IStatusRepository
{
	private readonly ApplicationDbContext _dbContext;

	public StatusRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Result<IEnumerable<Status>>> GetAllAsync(CancellationToken cancellationToken)
		=> await _dbContext.Statuses.Where(s => s.ParentStatus == null).ToListAsync();
}
