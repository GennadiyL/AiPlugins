namespace DataAccess.EntityFramework.MsSql;

public interface IAppDbMigrationService
{
	/// <summary>
	/// Applies pending database migrations and reports the resulting migration state.
	/// </summary>
	public Task<DbMigrationResult> ApplyAsync(CancellationToken cancellationToken = default);
}
