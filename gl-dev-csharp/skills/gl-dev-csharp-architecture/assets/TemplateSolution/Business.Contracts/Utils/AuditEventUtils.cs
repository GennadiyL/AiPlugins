using Business.Models.Entities;

namespace Business.Contracts.Utils;

/// <summary>
/// Defines the audit-event utilities.
/// Provides stable, primitive transformations for audit-event models.
/// Business callers invoke these stateless methods directly.
/// The utilities are published from Business.Contracts for shared business use.
/// The class does not own workflows, persistence, or external integrations.
/// </summary>
public static class AuditEventUtils
{
	public static AuditEvent Process(AuditEvent auditEvent) => auditEvent;
}
