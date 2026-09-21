using Business.Core.Entities;

namespace Business.Models.Exceptions;

/// <summary>
/// Defines the invalid audit-event search failure.
/// Signals that an audit-event search request violates business validation rules.
/// The audit-event service throws it before querying data access for invalid criteria.
/// It derives from BaseException so infrastructure can treat it as an expected business failure.
/// It does not select an HTTP response or log itself.
/// </summary>
public sealed class InvalidAuditEventSearchException : BaseException
{
	public InvalidAuditEventSearchException()
	{
	}

	public InvalidAuditEventSearchException(string? message) : base(message)
	{
	}

	public InvalidAuditEventSearchException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
