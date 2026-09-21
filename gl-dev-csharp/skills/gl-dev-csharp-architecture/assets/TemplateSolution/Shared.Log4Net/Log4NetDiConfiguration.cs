using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;

namespace Shared.Log4Net;

/// <summary>
/// Defines the Log4Net composition entry point.
/// Replaces the default logger with the Log4Net-backed ILogService implementation.
/// Hosts call this module during startup when Log4Net is selected.
/// It extends the shared contract through a third-party technology project.
/// It contains no logging calls or business behavior.
/// </summary>
public static class Log4NetDiConfiguration
{
	public static void AddDataAccessModule(this IServiceCollection services)
	{
		services.AddScoped<ILogService, Log4NetLogService>();
	}
}
