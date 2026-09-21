using Business.Contracts.Services;
using Business.Contracts.Services.AuditEvent;
using Messaging.Contracts.Models;
using Shared.Contracts.Messaging;

namespace Messaging.InProcessBus.Handlers;

/// <summary>
/// Defines the in-process audit-event confirmation handler.
/// Handles an audit-event confirmation message by invoking the required business service.
/// InProcessBusMessageService resolves a scoped handler through the dependency injection container.
/// It bridges the business-specific message contract to IAuditEventService.
/// It does not publish remotely or own message transport concerns.
/// </summary>
internal sealed class AuditEventConfirmationHandler : IMessageHandler<AuditEventConfirmationMessage>
{
	private readonly IAuditEventService _service;

	public AuditEventConfirmationHandler(IAuditEventService service) => _service = service;

	public Task Handle(AuditEventConfirmationMessage message) =>
		_service.GetAuditEventsAsync(new GetAuditEvents
		{
			From = message.From,
			To = message.To,
			PageNumber = 1,
			PageSize = 1000000
		});
}
