---
name: gl-dev-csharp-architecture
description: Use when creating, adding, moving, or reviewing .NET solution folders, physical project folders, projects, layer boundaries, dependency injection registrations, implementation visibility, or shared application context in a GL solution.
---

# GL Dev CSharp Architecture

Preserve the solution's established boundaries. Apply `gl-dev-csharp-common` whenever this work changes C# source.

## Template solution

`assets/TemplateSolution` is the single source of truth for the concrete GL solution scaffold: solution folders, projects, project references, namespaces, dependency injection composition, and representative implementations. Inspect the current asset whenever creating, extending, restructuring, or reviewing a solution; do not rely on a duplicated or remembered project tree.

- For a new complete solution, copy the template, replace the `TemplateSolution` name where appropriate, and remove optional projects that the requested solution does not need.
- For partial generation, copy only the requested projects or files together with their required project-reference dependencies. Preserve the current patterns demonstrated by the asset.
- For an existing solution, use the template as a reference and preserve user-established structure unless the task explicitly authorizes restructuring.
- Keep the asset free of generated and machine-local output, including `bin`, `obj`, `.vs`, test results, caches, logs, and user-specific IDE files.
- Preserve empty canonical folders through their `.gitkeep` files. Remove a placeholder when adding a real file to that folder.
- Update the asset directly when the canonical scaffold changes. Do not create or depend on an external synchronization copy.

## Folder terminology

Use `solution folder`, `physical folder`, and `project-internal folder` precisely. Solution folders are hierarchical groupings stored in the `.sln` or `.slnx`; physical folders are directories on disk; project-internal folders are physical folders inside a project. `TemplateSolution` uses hierarchical solution folders while keeping physical project folders flat under the physical solution root. Read the full definitions in [references/solution-structure.md](references/solution-structure.md#terminology).

## Solution structure

When creating or restructuring a solution, adding a project, or deciding where a project belongs, inspect `assets/TemplateSolution` and read [references/solution-structure.md](references/solution-structure.md). The asset defines the concrete structure; the reference explains responsibilities, optionality, and placement decisions. Add only projects required by the solution.

- Keep contracts, implementations, models, shared context, data access, and tests in their respective projects and folders.
- Preserve existing user-established project, contract-folder, and naming refactors. Do not reorganize unrelated code merely to normalize the solution.
- Register implementations through the applicable `{Domain}DiConfiguration`. For example, register repository implementations through `DataAccessDiConfiguration`.
- **REQUIRED SUB-SKILL:** Use `gl-dev-csharp-shared` for Shared projects, `ISharedContext`, project-independent services, and messaging implementation selection.

## Project types and dependencies

Classify every project by its architectural role:

| Type | Responsibility |
|---|---|
| Models | Stores POCO entities without behavior. Shared DTOs used by multiple Contracts projects may also be placed here. |
| Contracts | Stores interfaces, DTOs, and primitive helpers. |
| Impl | Implements functionality exposed through contracts. |
| Entry Point | Composes an executable environment. Infrastructure hosts and test projects have this role. |

- Keep concrete implementation classes `internal`. Use `public abstract` for reusable implementation bases. Public DI/module-configuration classes are allowed so Entry Points and extending modules can register the implementation. A framework-required technology type such as `AppDbContext` may be public as a narrow exception.
- An Impl project normally references only Contracts and Models projects. An Impl-to-Impl reference is allowed for a functional extension, normally by inheriting a public abstract implementation base. Provider-specific projects may reference their provider-neutral technology implementation as demonstrated by `DataAccess.EntityFramework.MsSql` and `DataAccess.EntityFramework.SqLite`; do not use this exception to call arbitrary concrete implementations.
- A Contracts project references its applicable Models project. Avoid Contracts-to-Contracts references. Permit them for trivial foundational contracts such as `IMessage`; when shared DTO dependencies become complex, copy the DTOs or move them into a Models project referenced by both Contracts projects.
- An Entry Point references every Impl project selected for its execution environment because it owns the final dependency composition. It does not reference unused alternative implementations. Read [the execution-environment guidance](references/solution-structure.md#execution-environments) when choosing the implementation set.
