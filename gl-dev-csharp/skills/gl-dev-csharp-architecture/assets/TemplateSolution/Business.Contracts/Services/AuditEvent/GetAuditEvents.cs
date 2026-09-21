namespace Business.Contracts.Services.AuditEvent;

/// <summary>
/// Defines the audit-event search request.
/// Carries optional date filters and required paging values into the business service.
/// Callers initialize its properties before invoking IAuditEventService.
/// The audit-event service validates this DTO and forwards its criteria to the repository.
/// It contains no validation or query behavior.
/// </summary>
public sealed record GetAuditEvents
{
	public DateTime? From { get; init; }
	public DateTime? To { get; init; }
	public int PageNumber { get; init; }
	public int PageSize { get; init; }
}
