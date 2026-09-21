using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.EntityFramework.MsSql;

/// <summary>
/// Defines the SQL Server data-access composition entry point.
/// Configures AppDbContext for SQL Server and registers migration support.
/// Infrastructure hosts call the module with application configuration during startup.
/// It builds on the provider-independent Entity Framework registrations.
/// It contains composition logic only and does not open database sessions itself.
/// </summary>
public static class MsSqlDiConfiguration
{
	public static void AddDataAccessMsSqlModule(this IServiceCollection services, IConfiguration configuration)
	{
		ArgumentNullException.ThrowIfNull(configuration);

		string connectionString = configuration.GetConnectionString("AppDb")
			?? throw new InvalidOperationException("Connection string 'AppDb' is not configured.");

		services.AddDataAccessEntityFrameworkModule();
		services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
		services.AddScoped<IAppDbMigrationService, AppDbMigrationService>();
	}
}
