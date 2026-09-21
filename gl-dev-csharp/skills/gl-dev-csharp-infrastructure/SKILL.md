---
name: gl-dev-csharp-infrastructure
description: Use when implementing or reviewing GL external-system adapters, provider authentication or data conversion, message-bus hosts or consumers, or deciding whether integration and authorization behavior belongs in infrastructure.
---

# GL Dev CSharp Infrastructure

Keep provider-specific mechanics at the application boundary. Apply `gl-dev-csharp-common` to C# source and follow `gl-dev-csharp-architecture` for visibility and registration.

**REQUIRED SUB-SKILL:** Use `gl-dev-csharp-shared` when implementing `{Solution}.MessageBus`, `IMessageService`, `Messaging.{Tech}Bus`, or another third-party message-publishing implementation.

- Define adapter contracts as public interfaces in `{Domain}.Contracts/Adapters`.
- Keep external adapters thin: authenticate with the provider and convert data to and from the provider format.
- Keep business workflows in the application rather than embedding them in adapters.
- Treat authorization as an application responsibility; do not introduce a separate `IAuthorizationAdapter`.
