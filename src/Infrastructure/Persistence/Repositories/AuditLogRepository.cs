using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
	public Task<AuditLog> CreateAuditLogAsync(AuditLogCreate auditCreate)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<AuditLog>> GetAuditLogsForEntityAsync(string entityType, string entityId)
	{
		throw new NotImplementedException();
	}

	public Task<AuditLog?> GetFirstAuditLogForEntityAsync(string entityType, string entityId)
	{
		throw new NotImplementedException();
	}

	public Task<AuditLog?> GetLatestAuditLogForEntityAsync(string entityType, string entityId)
	{
		throw new NotImplementedException();
	}
}
