using Business.Contracts.Services.AuditEvent;

namespace Business.Contracts.Services;

public interface IAuditEventService
{
	/// <summary>
	/// Retrieves a validated, paged audit-event result for the supplied search request.
	/// </summary>
	public Task<AuditEventInfos> GetAuditEventsAsync(
		GetAuditEvents input,
		CancellationToken cancellationToken = default);
}
