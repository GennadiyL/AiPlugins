namespace DataAccess.EntityFramework.MsSql;

/// <summary>
/// Defines the database migration result.
/// Reports which migration identifiers were pending and which are applied after migration.
/// IAppDbMigrationService returns the immutable result to the invoking host.
/// It is specific to the SQL Server migration integration boundary.
/// It does not perform migration work or retain a database context.
/// </summary>
public sealed record DbMigrationResult(IReadOnlyList<string> PendingMigrationIds, IReadOnlyList<string> AppliedMigrationIds);
