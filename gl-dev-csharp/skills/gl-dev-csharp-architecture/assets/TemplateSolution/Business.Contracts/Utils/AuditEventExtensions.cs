using Business.Models.Entities;

namespace Business.Contracts.Utils;

/// <summary>
/// Defines the audit-event extension utilities.
/// Provides stable, primitive extension behavior shared by audit-event callers.
/// Callers invoke the methods directly without dependency injection.
/// The utilities operate on business audit-event models exposed by Business.Models.
/// Changeable workflows and dependency-based behavior do not belong in this class.
/// </summary>
public static class AuditEventExtensions
{
	public static AuditEvent Calc(this AuditEvent auditEvent) => auditEvent;
}
