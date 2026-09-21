---
name: gl-dev-csharp-shared
description: Use when implementing or reviewing GL Shared.Contracts, Shared.Impl, ISharedContext, project-independent services, file or directory access, date and time access, serialization, logging, ZIP handling, or message publishing.
---

# GL Dev CSharp Shared

Keep Shared functionality business-agnostic and reusable across projects. Apply `gl-dev-csharp-common` to C# source and `gl-dev-csharp-architecture` when changing project boundaries or registrations.

When placing Shared projects, defining shared service contracts, or using `ISharedContext`, read [references/shared-project-structure.md](references/shared-project-structure.md).

When implementing `IMessageService`, in-process dispatch, third-party message publishing, message handlers, or messaging registrations, read [references/shared-project-messaging.md](references/shared-project-messaging.md).

## Boundaries

- Expose project-independent service abstractions from `Shared.Contracts`.
- Put standard implementations in `Shared.Impl`, non-messaging technology-specific implementations in `Shared.{Tech}`, and external message-publisher implementations in `Messaging.{Tech}Bus`.
- Keep Shared projects independent of business domains, concrete business messages, in-process business handlers, and application hosts.
- Pass `ISharedContext` into business-layer code that needs shared functionality and consume its contained services directly.
