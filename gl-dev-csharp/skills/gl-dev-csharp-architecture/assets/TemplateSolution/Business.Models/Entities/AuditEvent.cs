using Business.Core.Entities;

namespace Business.Models.Entities;

/// <summary>
/// Defines the persistent audit-event business model.
/// Stores the business representation of an event recorded for an aggregate.
/// Data access maps instances to and from storage while services consume them as anemic models.
/// It derives from BaseEntity for Guid identity shared across persistent business models.
/// It contains data only and does not implement business behavior.
/// </summary>
public class AuditEvent : BaseEntity
{
	public AuditEvent()
	{
	}

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
