using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.MsSql;

/// <summary>
/// Defines the SQL Server migration service.
/// Applies pending Entity Framework migrations and reports pending and applied identifiers.
/// A host resolves the scoped service when database migration is part of startup or deployment.
/// It operates on AppDbContext configured by the SQL Server module.
/// It does not configure the connection or own application startup policy.
/// </summary>
internal sealed class AppDbMigrationService(AppDbContext dbContext) : IAppDbMigrationService
{
	public async Task<DbMigrationResult> ApplyAsync(CancellationToken cancellationToken = default)
	{
		IReadOnlyList<string> pendingMigrationIds =
			[.. await dbContext.Database.GetPendingMigrationsAsync(cancellationToken)];

		await dbContext.Database.MigrateAsync(cancellationToken);

		IReadOnlyList<string> appliedMigrationIds =
			[.. await dbContext.Database.GetAppliedMigrationsAsync(cancellationToken)];

		return new DbMigrationResult(pendingMigrationIds, appliedMigrationIds);
	}
}
