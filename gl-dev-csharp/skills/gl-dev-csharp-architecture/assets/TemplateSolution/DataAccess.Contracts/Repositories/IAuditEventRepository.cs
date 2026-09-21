using Business.Models.Entities;
using DataAccess.Core.Behaviors;

namespace DataAccess.Contracts.Repositories;

public interface IAuditEventRepository : IRepository<AuditEvent>
{
	public Task<ICollection<AuditEvent>> GetAuditEventsAsync(
		DateTime? from,
		DateTime? to,
		int skip,
		int take,
		CancellationToken cancellationToken);
	public Task<long> CountAuditEventsAsync(
		DateTime? from,
		DateTime? to,
		CancellationToken cancellationToken);
}
