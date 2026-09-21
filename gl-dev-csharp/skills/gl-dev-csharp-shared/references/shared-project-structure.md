# Shared Project Structure

Use Shared for project-independent functionality that business logic can reuse without depending on a particular business domain, infrastructure host, or external provider.

## Projects

```text
Shared/
|-- Shared.Contracts/
|-- Shared.Impl/
|-- Shared.{Tech1}/
`-- Shared.{Tech2}/
```

- `Shared.Contracts` contains public, project-independent service abstractions and `ISharedContext`.
- `Shared.Impl` contains standard implementations of those contracts without additional third-party library dependencies.
- `Shared.{Tech}` contains non-messaging implementations backed by a particular technology or third-party library. Create such a project only when that implementation is required; external message-publisher implementations belong in `Messaging.{Tech}Bus`.

## Shared.Contracts services

| Contract | Responsibility |
|---|---|
| `IJsonService` | Work with JSON files. |
| `IXmlService` | Work with XML files. |
| `IFileService` | Perform file operations. Use this service instead of static members of `File`. |
| `IDirectoryService` | Perform directory operations. Use this service instead of static members of `Directory`. |
| `IDateTimeService` | Provide date and time operations. Use this service instead of static members of `DateTime`. |
| `ILogService` | Perform logging. |
| `IZipService` | Work with ZIP files. |
| `IMessageService` | Publish messages. See [shared-project-messaging.md](shared-project-messaging.md). |

Add another shared contract only when business logic requires the service and its responsibility is business-agnostic.

## ISharedContext

`ISharedContext` is a POCO container for the shared services required by business logic.

- Pass this specific context into business-layer methods and services that need shared functionality.
- Consume shared services directly from the context rather than passing each contained service separately.
- Keep the context project-independent; do not add domain-specific services or application-host state.

## Shared.Impl

`Shared.Impl` contains the following standard implementations without additional third-party library dependencies:

| Contract | Implementation |
|---|---|
| `IJsonService` | `JsonService` |
| `IXmlService` | `XmlService` |
| `IFileService` | `FileService` |
| `IDirectoryService` | `DirectoryService` |
| `IDateTimeService` | `DateTimeService` |
| `ILogService` | `NullLogService` |
| `IZipService` | `ZipService` |
| `IMessageService` | `InProcessBusMessageService` |
| `ISharedContext` | `SharedContext` |

`NullLogService` is the standard no-op logging implementation. `InProcessBusMessageService` is the standard in-process message-publishing implementation; see [shared-project-messaging.md](shared-project-messaging.md).

The `Shared.Impl` DI configuration registers `NullLogService` for `ILogService` and `InProcessBusMessageService` for `IMessageService` by default. Register an external publisher from `Messaging.{Tech}Bus` after this module to replace the default `IMessageService` selection.

## Shared.{Tech}

A `Shared.{Tech}` project uses a third-party library to provide one or more non-messaging implementations of contracts from `Shared.Contracts`. The technology name identifies the implementation project; it does not make that technology mandatory. External message-publisher implementations belong in `Messaging.{Tech}Bus` instead.

| Example project | Implementation | Responsibility |
|---|---|---|
| `Shared.Log4Net` | `Log4NetLogService : ILogService` | Implements logging through Log4Net. |
| `Shared.Serilog` | `SerilogLogService : ILogService` | Implements logging to a remote server through Serilog. |
