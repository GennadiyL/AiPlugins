using Shared.Contracts;
using Shared.Contracts.Messaging;

namespace Messaging.AzureBus;

/// <summary>
/// Defines the remote message-bus publisher.
/// Provides the third-party-backed IMessageService implementation for remote publication.
/// The dependency injection container creates a scoped publisher for business consumers.
/// It implements the shared publisher contract while transport details stay in this project.
/// Its transport call remains intentionally unfinished in the reference template.
/// </summary>
internal class AzureBusMessageService : IMessageService
{
	public async Task PublishAsync<T>(T message) where T : IMessage => await Task.CompletedTask;
}
