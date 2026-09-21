using Business.Contracts.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.Sms;

/// <summary>
/// Defines the SMS adapter composition entry point.
/// Registers the SMS adapter implementation with the application dependency injection container.
/// Host projects call this configuration during startup when SMS delivery is required.
/// It connects ISmsAdapter consumers to the adapter-layer implementation.
/// It contains composition logic only and does not send messages itself.
/// </summary>
public static class SmsDiConfiguration
{
	public static void AddAdapterSmsModule(this IServiceCollection services)
	{
		services.AddScoped<ISmsAdapter, SmsAdapter>();
	}
}
