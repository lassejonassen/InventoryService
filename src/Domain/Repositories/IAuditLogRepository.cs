using InventoryService.Domain.Entities;

namespace InventoryService.Domain.Repositories;

public interface IAuditLogRepository
{
	Task<AuditLog> CreateAuditLogAsync(AuditLogCreate auditCreate);
	Task<IEnumerable<AuditLog>> GetAuditLogsForEntityAsync(string entityType, string entityId);
	Task<AuditLog?> GetLatestAuditLogForEntityAsync(string entityType, string entityId);
	Task<AuditLog?> GetFirstAuditLogForEntityAsync(string entityType, string entityId);
}
