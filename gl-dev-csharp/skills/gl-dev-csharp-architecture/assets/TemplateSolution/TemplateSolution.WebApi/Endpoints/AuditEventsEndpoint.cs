using Business.Contracts.Services;
using Business.Contracts.Services.AuditEvent;

namespace TemplateSolution.WebApi.Endpoints;

/// <summary>
/// Defines the audit-events Web API endpoint.
/// Defines the HTTP route that invokes the audit-event business service.
/// WebApiEndpointsConfiguration maps the endpoint during application startup.
/// The handler binds the public request DTO and returns the public result DTO.
/// It does not access data repositories or contain business rules.
/// </summary>
public static class AuditEventsEndpoint
{
	public static async Task<IResult> GetAuditEventsHandler([AsParameters] GetAuditEvents input, IAuditEventService service, CancellationToken cancellationToken = default)
	{
		AuditEventInfos  result = await service.GetAuditEventsAsync(input, cancellationToken);
		return Results.Ok(result);
	}
}
