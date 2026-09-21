using Business.Models.Entities;

namespace Business.Contracts.Utils;

/// <summary>
/// Defines the audit-event helper utilities.
/// Provides stable, primitive helper behavior for audit-event models.
/// Business callers invoke these stateless methods directly.
/// The helpers are part of the public business contract utility surface.
/// Complex or changeable behavior must be implemented behind an interface instead.
/// </summary>
public static class AuditEventHelpers
{
	public static string Validate(AuditEvent auditEvent) => string.Empty;
}
