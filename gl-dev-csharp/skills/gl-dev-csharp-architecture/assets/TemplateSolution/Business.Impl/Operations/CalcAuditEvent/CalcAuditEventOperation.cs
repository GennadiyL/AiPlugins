using Business.Models.Entities;

namespace Business.Impl.Operations.CalcAuditEvent;

/// <summary>
/// Defines the audit-event calculation operation.
/// Holds separately testable internal calculation behavior used by business services.
/// The dependency injection container creates a scoped instance through ICalcAuditEventOperation.
/// It belongs to Business.Impl and operates on the persistent AuditEvent model.
/// Its sample calculation remains intentionally unfinished in the reference template.
/// </summary>
internal class CalcAuditEventOperation : ICalcAuditEventOperation
{
	public string Calc(AuditEvent auditEvent)
	{
		throw new NotImplementedException();
	}
}
