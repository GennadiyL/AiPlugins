using DataAccess.Core.Entities;

namespace DataAccess.EntityFramework.Models;

/// <summary>
/// Defines the audit-event data-access entity.
/// Represents the database shape persisted for an audit event.
/// Entity Framework materializes instances and AppMapper converts them to business models.
/// It implements IDalEntity and is configured through AppDbContext.
/// It remains internal and does not cross the data-access boundary.
/// </summary>
internal class AuditEvent : IDalEntity
{
	public Guid Id { get; set; }

	public DateTime OccurredAt { get; set; }
	public string EventType { get; set; } = string.Empty;
	public string AggregateType { get; set; } = string.Empty;
	public Guid AggregateId { get; set; }
	public string CorrelationId { get; set; } = string.Empty;
	public string ActorType { get; set; } = string.Empty;
	public string? ActorReference { get; set; }
	public string EventDataJson { get; set; } = string.Empty;
	public string Source { get; set; } = string.Empty;
}
