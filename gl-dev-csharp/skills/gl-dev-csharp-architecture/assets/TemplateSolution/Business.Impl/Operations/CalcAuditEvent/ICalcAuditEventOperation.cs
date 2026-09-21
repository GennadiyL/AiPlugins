using Business.Models.Entities;

namespace Business.Impl.Operations.CalcAuditEvent;

internal interface ICalcAuditEventOperation
{
	public string Calc(AuditEvent auditEvent);
}