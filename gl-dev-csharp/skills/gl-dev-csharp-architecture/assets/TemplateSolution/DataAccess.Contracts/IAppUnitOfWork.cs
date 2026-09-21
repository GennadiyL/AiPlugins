using DataAccess.Contracts.Repositories;
using DataAccess.Core.Entities;

namespace DataAccess.Contracts;

public interface IAppUnitOfWork : IUnitOfWork
{
	public IAuditEventRepository AuditEventRepo { get; }
}
