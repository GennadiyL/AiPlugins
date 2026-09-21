using Business.Contracts.Services;
using Business.Contracts.Services.AuditEvent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace TemplateSolution.AzureFunctions.AzureFunctions;

/// <summary>
/// Defines the audit-events Azure Functions endpoint.
/// Exposes audit-event business operations through Azure Functions HTTP triggers.
/// The Functions runtime creates the endpoint class and injects IAuditEventService.
/// It binds transport input, delegates to the business contract, and returns an HTTP result.
/// It does not query repositories or implement business rules.
/// </summary>
public sealed class AuditEventsFunctions(IAuditEventService service)
{
	[Function(nameof(GetAuditEvents))]
	public async Task<IActionResult> GetAuditEvents(
		[HttpTrigger(AuthorizationLevel.Function, "post", Route = "audit-events/get-audit-events")] HttpRequest request,
		CancellationToken cancellationToken)
	{
		(GetAuditEvents? input, IActionResult? error) =
			await HttpRequestBinding.ReadJsonAsync<GetAuditEvents>(request, cancellationToken);
		if (error is not null)
		{
			return error;
		}
		AuditEventInfos result = await service.GetAuditEventsAsync(input!, cancellationToken);
		return new OkObjectResult(result);
	}
}
