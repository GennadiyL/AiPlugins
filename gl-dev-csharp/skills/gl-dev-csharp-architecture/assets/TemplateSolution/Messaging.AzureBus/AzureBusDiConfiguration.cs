using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;

namespace Messaging.AzureBus;

/// <summary>
/// Defines the remote message-bus composition entry point.
/// Registers the selected remote message-bus publisher implementation.
/// Production hosts call this module when messages must be dispatched outside the current process.
/// It replaces the default IMessageService registration with AzureBusMessageService.
/// The module does not define business messages or subscriber handlers.
/// </summary>
public static class AzureBusDiConfiguration
{
	public static void AddMessagingAzureBusModule(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IMessageService, AzureBusMessageService>();
	}
}
