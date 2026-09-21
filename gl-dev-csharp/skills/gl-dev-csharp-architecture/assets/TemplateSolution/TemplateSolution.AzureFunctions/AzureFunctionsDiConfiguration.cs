using Business.Impl;
using DataAccess.EntityFramework.MsSql;
using Messaging.AzureBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Impl;

namespace TemplateSolution.AzureFunctions;

/// <summary>
/// Defines the Azure Functions composition entry point.
/// Registers the application modules required by the Azure Functions host.
/// The Functions startup path invokes this configuration once while building the host.
/// It composes business, data-access, shared, adapter, and messaging modules.
/// It does not implement trigger handlers or business workflows.
/// </summary>
public static class AzureFunctionsDiConfiguration
{
	public static void AddTemplateSolutionAzureFunctionsDiConfiguration(
		this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSharedModule();
		services.AddBusinessModule();
		services.AddDataAccessMsSqlModule(configuration);
		services.AddMessagingAzureBusModule(configuration);
	}
}
