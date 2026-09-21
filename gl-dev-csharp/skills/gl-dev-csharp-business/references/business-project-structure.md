# Business Project Structure

Use this reference when placing types inside the main Business projects or their equivalents in another business domain. The [TemplateSolution asset](../../gl-dev-csharp-architecture/assets/TemplateSolution) is the single source of truth for concrete project and folder structure; this reference explains the placement rules demonstrated by that asset.

Use the terms `solution folder`, `physical folder`, and `project-internal folder` as defined in the [architecture terminology](../../gl-dev-csharp-architecture/references/solution-structure.md#terminology). The template groups projects with hierarchical solution folders while keeping their physical project folders flat under the physical solution root.

## Business.Models

```text
Business.Models/
|-- Enums/
|-- Constants/                 # Optional; create only when constants exist
|-- Entities/
`-- Exceptions/
```

`Business.Models` contains persistent models, enums, exceptions, and constants shared across the business domains.

- Add a type only when it is genuinely shared rather than owned by one domain.
- Do not put behavior-based entities in this project. Its entities represent persistent state, not business workflows or behavior-centric domain objects.

## Business.Contracts

```text
Business.Contracts/
|-- Adapters/
|   |-- CustomerOne/              # DTOs and enums for ICustomerOneAdapter
|   |-- CustomerTwo/              # DTOs and enums for ICustomerTwoAdapter
|   |-- ICustomerOneAdapter.cs
|   `-- ICustomerTwoAdapter.cs
|-- Services/
|   |-- One/                      # DTOs and enums for IOneService
|   |-- Two/                      # DTOs and enums for ITwoService
|   |-- IOneService.cs
|   `-- ITwoService.cs
`-- Utils/
    |-- Utils1.cs
    |-- Utils2.cs
    |-- Extensions1.cs
    `-- Extensions2.cs
```

The example names are placeholders; use the actual adapter, service, utility, and extension names.

### Adapter contracts

- Keep public interfaces for external-system adapters under `Business.Contracts/Adapters`.
- Keep each adapter's DTOs and adapter-specific enums in a sibling folder named from the interface without the leading `I` or trailing `Adapter`, such as `Adapters/CustomerOne` for `ICustomerOneAdapter`.

### Service contracts

- Keep public service interfaces under `Business.Contracts/Services`.
- Keep each service's DTOs and service-specific enums in a sibling folder named from the interface without the leading `I` or trailing `Service`, such as `Services/One` for `IOneService`.
- These DTOs and enums are exclusive to parameters and return values of the corresponding service contract.

### Utilities and extensions

- `Utils` contains public static utility and extension classes only when the behavior is primitive, dependency-free, stable, and not reasonably expected to require substitution or independent evolution.
- If behavior represents an evolving policy, business workflow, external interaction, or replaceable dependency, use the standard public contract plus internal implementation approach instead.

## Business.Impl

```text
Business.Impl/
|-- Operations/
|   |-- One/
|   |   |-- IOneOperation.cs
|   |   |-- OneOperation.cs
|   |   `-- Operation DTO files
|   `-- Two/
|       |-- ITwoOperation.cs
|       |-- TwoOperation.cs
|       `-- Operation DTO files
|-- Services/
|   |-- OneService.cs
|   `-- TwoService.cs
|-- Utils/                     # Optional; create only when suitable utilities exist
`-- BusinessDiConfiguration.cs
```

`Business.Impl` contains the internal implementation of business services.

### Services

- Keep service implementations under `Business.Impl/Services`.
- Service implementations are `internal` and implement the corresponding public contracts from `Business.Contracts`.

### Operations

- Give each operation its own folder under `Business.Impl/Operations`.
- Co-locate the operation interface, implementation, and DTOs in that folder. For example, `Operations/One` contains `IOneOperation`, `OneOperation`, and the DTOs used by that operation.
- Operation interfaces, implementations, and DTOs are all `internal` and remain project-local.
- Use an operation for a substantial or complex business subflow that benefits from isolated unit testing, must be mockable in service tests, or is reused within `Business.Impl`.

The presence of `Utils` and `BusinessDiConfiguration` is recorded here; their detailed behavior and visibility are defined separately.

## Other Business Domains

For every other business domain `{DomainN}`, apply the same project-structure and type-placement rules as for the main Business layer, replacing each occurrence of `Business` with `{DomainN}`.

Place the projects for a regular domain in a dedicated top-level solution folder:

```text
{DomainN}/
|-- {DomainN}.Models/
|-- {DomainN}.Contracts/
`-- {DomainN}.Impl/
```

For an area identified as a subdomain during a particular implementation:

- Omit the `{DomainN}.Models` project.
- Consolidate everything that would belong to `{DomainN}.Models` and `{DomainN}.Contracts` into `{DomainN}.Contracts`.
- Place `{DomainN}.Contracts` and `{DomainN}.Impl` directly inside the top-level `Business` solution folder.

```text
Business/
|-- {DomainN}.Contracts/
`-- {DomainN}.Impl/
```

Use the regular-domain layout unless the particular implementation explicitly identifies the area as a subdomain. The criteria for making that decision are implementation-specific.
