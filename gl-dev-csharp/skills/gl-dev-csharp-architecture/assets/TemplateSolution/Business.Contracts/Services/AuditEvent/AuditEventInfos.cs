namespace Business.Contracts.Services.AuditEvent;

/// <summary>
/// Defines the paged audit-event result.
/// Carries audit-event DTOs together with paging metadata.
/// The audit-event service initializes the scalar properties and fills the stable get-only collection.
/// It is the return contract for IAuditEventService.GetAuditEventsAsync.
/// It does not query storage or calculate paging values.
/// </summary>
public sealed record AuditEventInfos
{
	public ICollection<AuditEventInfo> AuditEventInfosList { get; } = new List<AuditEventInfo>();
	public long PageNumber { get; init; }
	public long PageSize { get; init; }
	public long Total { get; init; }
}
