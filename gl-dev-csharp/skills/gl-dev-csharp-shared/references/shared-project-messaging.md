# Shared Project Messaging

Use this reference for outbound message publishing, local in-process dispatch, third-party transport implementations, and production message-bus handling.

## Project responsibilities

| Project | Responsibility |
|---|---|
| `Shared.Contracts` | Defines the public `IMessageService` publishing contract and reusable messaging abstractions such as `IMessage` and `IMessageHandler<TMessage>`. `IMessageService` exposes message publishing only. |
| `Messaging.Contracts` | Contains concrete, business-specific message DTOs. |
| `Messaging.InProcessBus` | Contains concrete, business-specific in-process handlers for messages from `Messaging.Contracts`. |
| `Shared.Impl` | Contains `InProcessBusMessageService`, the project-independent in-process implementation of `IMessageService`. |
| `Messaging.{Tech}Bus` | Contains a project-independent external implementation of `IMessageService` backed by the selected message technology. `Messaging.AzureBus` and `AzureBusMessageService` are examples; another third-party transport may be used. |
| `Infrastructure/{Solution}.MessageBus` | Hosts production transport consumers. Each consumer receives a message from the external message bus and invokes the applicable business service. |

## In-process dispatch

`InProcessBusMessageService` dispatches messages through dependency injection; it does not reference `Messaging.InProcessBus` or concrete business message types.

For each published message:

1. Select and cache an internal dispatcher wrapper by the message's runtime type.
2. Create a dependency-injection scope for the dispatch.
3. Resolve all registered `IMessageHandler<TMessage>` implementations from that scope.
4. Invoke each resolved handler with the published message.

The application composition root references and registers the concrete handlers from `Messaging.InProcessBus`. Those registrations make the handlers discoverable without introducing a project dependency from `Shared.Impl` to `Messaging.InProcessBus`.

```text
Business service
    -> IMessageService
    -> Shared.Impl/InProcessBusMessageService
    -> scoped IMessageHandler<TMessage> registrations
    -> Messaging.InProcessBus handler
    -> applicable business service
```

## Remote dispatch

The external implementation publishes the same business message through the selected transport. Keep this publisher solution-independent: it depends on reusable messaging contracts, not on concrete business messages, handlers, or application hosts.

```text
Business service
    -> IMessageService
    -> Messaging.{Tech}Bus/{Tech}BusMessageService
    -> external message bus
    -> Infrastructure/{Solution}.MessageBus consumer
    -> applicable business service
```

Do not make business code depend on the selected transport library. Each implementation project registers its internal implementation through that project's public DI-configuration entry point. The application composition root chooses which DI configuration to invoke without referencing the internal implementation class.

Register the in-process implementation in `Shared.Impl` by default:

```csharp
services.AddScoped<IMessageService, InProcessBusMessageService>();
```

For an external transport, register its implementation after `Shared.Impl` so it becomes the selected `IMessageService`:

```csharp
services.AddScoped<IMessageService, AzureBusMessageService>();
```
