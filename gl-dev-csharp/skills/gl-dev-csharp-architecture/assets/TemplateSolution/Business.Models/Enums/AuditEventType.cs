namespace Business.Models.Enums;

/// <summary>
/// Defines the audit-event category.
/// Defines the supported categories assigned to audit events.
/// Business models and contracts can use the values when classifying recorded activity.
/// The enumeration belongs to the shared persistent business-model project.
/// It does not encode processing rules for any category.
/// </summary>
public enum AuditEventType
{
	Undefined = 0,
	QueueUpdate = 1,
	Assignment = 2,
	SessionWarning = 3,
	Exception = 4
}
