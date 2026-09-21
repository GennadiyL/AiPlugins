using DataAccess.Contracts.Repositories;
using DataAccess.Core.Behaviors;
using DataAccess.Core.EntityFramework.Behaviors;
using DataAccess.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using AuditEventEntity = Business.Models.Entities.AuditEvent;

namespace DataAccess.EntityFramework.Repositories;

/// <summary>
/// Defines the audit-event repository.
/// Implements audit-event filtering, counting, paging, and common persistence operations.
/// The application unit of work exposes it through IAuditEventRepository.
/// It extends the generic Entity Framework repository with domain-specific queries.
/// It returns business models and does not expose queryable database entities.
/// </summary>
internal sealed class AuditEventRepository : Repository<AppDbContext, AuditEventEntity, AuditEvent>,
	IAuditEventRepository
{
	public AuditEventRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
	{
	}

	public async Task<ICollection<AuditEventEntity>> GetAuditEventsAsync(DateTime? from, DateTime? to, int skip, int take, CancellationToken cancellationToken)
	{
		List<AuditEvent> entities =
			await ApplyAuditEventSearch(Context.AuditEvents.AsNoTracking(), from, to)
				.OrderByDescending(x => x.OccurredAt).ThenByDescending(x => x.Id).Skip(skip).Take(take)
				.ToListAsync(cancellationToken);
		return Mapper.Map<AuditEvent, AuditEventEntity>(entities);
	}

	public Task<long> CountAuditEventsAsync(DateTime? from, DateTime? to, CancellationToken cancellationToken)
	{
		return ApplyAuditEventSearch(Context.AuditEvents.AsNoTracking(), from, to)
			.LongCountAsync(cancellationToken);
	}

	private static IQueryable<AuditEvent> ApplyAuditEventSearch(
		IQueryable<AuditEvent> auditEvents,
		DateTime? from,
		DateTime? to)
	{
		if (from.HasValue)
		{
			auditEvents = auditEvents.Where(x => x.OccurredAt >= from.Value);
		}

		if (to.HasValue)
		{
			auditEvents = auditEvents.Where(x => x.OccurredAt <= to.Value);
		}

		return auditEvents;
	}
}
