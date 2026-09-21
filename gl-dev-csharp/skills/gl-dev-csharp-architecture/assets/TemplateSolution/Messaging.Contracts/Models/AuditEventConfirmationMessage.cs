using Shared.Contracts.Messaging;

namespace Messaging.Contracts.Models;

/// <summary>
/// Defines the audit-event confirmation message.
/// Carries business-specific audit-event confirmation criteria across the messaging boundary.
/// Publishers initialize its properties before passing it to IMessageService.
/// Both in-process and remote subscribers consume the same IMessage contract.
/// It contains no transport metadata handling or subscriber behavior.
/// </summary>
public sealed record AuditEventConfirmationMessage : IMessage
{
	public DateTime? From { get; init; }
	public DateTime? To { get; init; }
	public Guid MessageId { get; init; }
	public Guid CorrelationId { get; init; }
}
