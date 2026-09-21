namespace Business.Contracts.Services.AuditEvent;

/// <summary>
/// Defines the audit-event result item.
/// Carries the public audit-event data returned by the audit-event service.
/// Service implementations create instances with property initializers for each matching persistent model.
/// It is nested in AuditEventInfos and crosses the business contract boundary.
/// It contains no persistence behavior or domain operations.
/// </summary>
public sealed record AuditEventInfo
{
	public Guid AuditEventId { get; init; }
	public DateTime OccurredAt { get; init; }
}
