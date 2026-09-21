# Solution Structure

The [TemplateSolution asset](../assets/TemplateSolution) is the single source of truth for the concrete solution topology, project names, project references, and example composition. Inspect its current files when creating a GL C# solution, adding projects, selecting a partial scaffold, or reviewing structure.

This reference explains how to interpret and select from the template. It intentionally does not duplicate the full tree, because that copy would become stale when the asset changes. Preserve established names and structure in an existing solution unless the task explicitly includes restructuring.

The template demonstrates available project roles; it is not a requirement to copy every domain, provider, host, adapter, messaging transport, or test project. When using only part of it, include the selected projects and their required project-reference dependencies.

## Terminology

| Term | Meaning |
|---|---|
| `Solution folder` | A hierarchical, virtual grouping recorded in a `.sln` or `.slnx` file. A solution folder may contain projects or nested solution folders and does not require a corresponding directory on disk. |
| `Physical folder` | A directory on disk. The physical solution root contains the solution file and, in `TemplateSolution`, the flat set of physical project folders. |
| `Physical project folder` | The physical folder containing one project file and that project's content. Its disk location is independent of the project's solution-folder hierarchy. |
| `Project-internal folder` | A physical folder inside a physical project folder, such as `Business.Contracts/Services` or `Business.Models/Entities`. |

`TemplateSolution` uses hierarchical solution folders in `TemplateSolution.slnx`, including nested solution folders such as `DataAccess/Domain1` and `Tests/ServiceTests`. Its physical project folders remain flat under the physical solution root, such as `Domain1.Contracts` and `ServiceTests.Business`.

## Solution-folder responsibilities

The following names identify solution folders in the `.slnx`; they do not require matching physical wrapper folders.

| Folder | Responsibility |
|---|---|
| `Core` | Contains domain-independent business and data-access foundations shared across domains. `Business.Core` owns business foundation types, `DataAccess.Core` owns persistence-neutral data-access abstractions, and `DataAccess.Core.EntityFramework` owns reusable EF Core base implementations. |
| `Business` | Contains the main shared business layer. A small solution may keep its entire business layer here. Subdomains use dedicated Contracts and Impl projects under this folder. |
| `{DomainN}` | Optional top-level folder for a large business domain. It contains separate Contracts, Impl, and Models projects. |
| `DataAccess` | Contains the complete data-access layer. Main DAL projects are placed directly under this folder; DAL projects owned by a large domain are grouped under `DataAccess/{DomainN}`. |
| `Infrastructure` | Contains application entry points and transport hosts, including Azure Functions, Web API, console applications, and production message consumers hosted by `{Solution}.MessageBus`. |
| `Messaging` | Contains business-specific message contracts and in-process handlers, plus solution-independent external message-publisher implementations such as `Messaging.AzureBus`. |
| `Adapters` | Contains custom implementations of external-system adapters. Keep adapter contracts with the owning business domain. |
| `Shared` | Contains project-independent contracts and non-messaging implementations. `Shared.Contracts` exposes shared services and `ISharedContext`, `Shared.Impl` provides standard implementations, and `Shared.{Tech}` provides replaceable technology-specific implementations such as logging providers. |
| `Tests` | Contains all shared test support, integration tests, service tests, and unit tests. Service and unit test projects mirror the business domains they exercise. |

## Core projects

- `Business.Core` contains domain-independent business foundation classes and interfaces such as `IBaseEntity`, `BaseEntity`, `IService`, `IAdapter`, `IOperation`, and `BaseException`.
- `DataAccess.Core` contains persistence-neutral foundation classes and interfaces such as `IDalEntity`, `IMapper`, `IRepository<T>`, `IUnitOfWork`, `IUnitOfWorkTransaction`, `ICommand`, and `IQuery`.
- `DataAccess.Core.EntityFramework` contains reusable EF Core base implementations such as `Repository<TContext, TBusiness, TDal>`, `UnitOfWork<TContext>`, and `UnitOfWorkTransaction`.
- DTOs and other auxiliary records do not implement `IBaseEntity`; it belongs to the persistent business-model foundation.
- Keep Core projects independent of particular business domains, database providers, and infrastructure hosts. `DataAccess.Core.EntityFramework` may depend on EF Core and `DataAccess.Core`, but not on provider-specific projects such as MsSql or SqLite.

For a small solution with a single business domain, the `Core` solution folder and its projects may be omitted. Place their types as follows:

| Destination project | Types |
|---|---|
| `Business.Models` | `IBaseEntity`, `BaseEntity`, `BaseException` |
| `Business.Contracts` | `IService`, `IAdapter`, `IOperation` |
| `DataAccess.Contracts` | `IDalEntity`, `IMapper`, `IRepository<T>`, `IUnitOfWork`, `IUnitOfWorkTransaction`, `ICommand`, `IQuery` |
| `DataAccess.EntityFramework` | EF Core base repository, unit-of-work, and transaction implementations |

## Placement rules

- Use the Core projects when domain-independent foundations must be shared across multiple business domains. A small, single-domain solution may use the compact placement above instead.
- Keep a subdomain under the `Business` solution folder when separate top-level domain grouping would add structure without improving ownership or isolation.
- Promote a large domain to its own optional top-level `{DomainN}` solution folder with Contracts, Impl, and Models projects.
- Place a large domain's DAL projects under the `DataAccess/{DomainN}` solution-folder hierarchy. Keep the domain name in each project name, such as `{DomainN}.DataAccess.Contracts` and `{DomainN}.DataAccess.EntityFramework`.
- Keep data-access technology and provider combinations explicit in project names, such as `DataAccess.EntityFramework.MsSql` and `DataAccess.Dapper.SqLite`.
- Keep `Messaging.Contracts`, `Messaging.InProcessBus`, and transport publisher projects such as `Messaging.AzureBus` under the top-level `Messaging` solution folder.
- Put executable entry points in the `Infrastructure` solution folder, not in the Business, DataAccess, Adapters, Messaging, or Shared solution folders.
- Put non-messaging third-party shared-service implementations in `Shared.{Tech}`. Put external message-publisher implementations in `Messaging.{Tech}Bus`.
- Add matching service-test and unit-test projects for each business area that requires those test levels.

## Execution environments

An Entry Point defines a complete executable environment by referencing the business implementation and every infrastructure implementation selected for that environment. Alternative implementations for other environments remain outside that Entry Point.

### Remote

The Remote environment is the production environment. A typical composition contains:

- An Azure Functions project as the infrastructure Entry Point.
- The applicable business-layer implementations.
- `DataAccess.EntityFramework.MsSql` as the DAL implementation.
- Remote external-system implementations, such as a Service Bus transport and an external payment service.

### Local

The Local environment runs on a developer computer without remote resources. A typical composition contains:

- A Web API hosted as a console application as the infrastructure Entry Point.
- The applicable business-layer implementations.
- `DataAccess.EntityFramework.SqLite` as the DAL implementation.
- In-process or mocked implementations of external systems.

Use the Local environment to test and debug the application without connecting to production infrastructure or other remote resources.
