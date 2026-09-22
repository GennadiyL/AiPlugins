---
name: gl-dev-csharp-data-access
description: Use when implementing or reviewing GL repositories, units of work, DAL persistence models, business-to-DAL aliases, or disconnected optimistic-concurrency contracts.
---

# GL Dev CSharp Data Access

Keep persistence abstractions aligned with business entities while isolating DAL representations. Apply `gl-dev-csharp-common` to C# source and `gl-dev-csharp-tech-ef-core` when the change depends on EF Core behavior.

## Project placement

Follow [references/data-access-structure.md](references/data-access-structure.md) for the canonical solution folders, project responsibilities, core-abstraction placement, and domain-specific variants. Use the `TemplateSolution` asset from `gl-dev-csharp-architecture` as the single source of truth when the reference and template disagree.

## Implementation rules

- Validate input and enforce business rules in the business/service layer. Pass valid data and criteria to the DAL. The DAL must not duplicate business validation or make business decisions. Defensive technical precondition checks required for safe persistence, such as null guards, are allowed.
- Business-layer services decide which repository operation, query, or command is appropriate for the use case. The DAL must not choose an API path, calculate business queue order, sort for business presentation, make authorization decisions, or reinterpret supplied criteria.
- Keep each DAL operation focused on four responsibilities: map business input to DAL input, build the database request represented by the supplied criteria, make at most one database call, and map the result back to business output. Use separate operations when both a count and a result set are required.
- Filtering, includes, database ordering, paging, and counting belong in the DAL when they are direct expressions of supplied criteria and are used to build the requested database operation.

  For example, conditional filters that directly translate supplied criteria are allowed:

  ```csharp
  private static IQueryable<AuditEvent> ApplyAuditEventSearch(
      IQueryable<AuditEvent> auditEvents,
      DateTime? from,
      DateTime? to)
  {
      if (from.HasValue)
          auditEvents = auditEvents.Where(x => x.OccurredAt >= from.Value);
      if (to.HasValue)
          auditEvents = auditEvents.Where(x => x.OccurredAt <= to.Value);

      return auditEvents;
  }
  ```

- A DAL operation may translate a provider exception into an existing business-domain exception only when the provider error has an unambiguous domain meaning, such as a unique-constraint, foreign-key, or concurrency violation. Preserve the provider exception as the inner exception. Do not infer a not-found exception from an empty result or a generic SQL exception.
- Put most data-access behavior in repositories. Repository entity payloads and results use persistent business models; repository boundaries must not expose DAL persistence models. Scalar criteria and criteria DTOs are allowed as inputs.
- A query performs a read operation. It may accept scalar criteria or DTOs and may return DTOs when the result is a projection rather than a persistent business entity.
- A command performs a create, update, or delete operation, commonly a bulk operation. It may use DTOs for input and may optionally return information about affected entities.
- Mapper behavior is directional. When converting DAL models to business models, map the complete graph already loaded by the repository, including loaded parent and child navigation properties. A mapper must not execute database queries. When converting a business model to a DAL model, map only the target object scalar values and foreign keys; do not recursively map referenced parents or children.
- DAL persistence models implement `IDalEntity` and expose an `Id` whose type is `Guid` or `long`.
- Maintain a repository interface for every domain entity in the applicable `{Scope}.DataAccess.Contracts/Repositories` project. For the main shared business layer, use `DataAccess.Contracts/Repositories`. Each interface derives from `IRepository<TEntity>` using its corresponding business-model entity.
- Implement EF Core repositories in the applicable `{Scope}.DataAccess.EntityFramework/Repositories` project. Each implementation implements its matching interface and derives from the shared EF Core repository base in `DataAccess.Core.EntityFramework`.
- `I{Project}UnitOfWork` exposes all repository interfaces. Each repository property resolves its interface through the configured service provider. Retain this lazy service-provider-based approach; do not constructor-inject every repository into the unit of work.
- Keep EF Core DAL model classes in the applicable `{Scope}.DataAccess.EntityFramework/Models` project folder and mark them `internal`.
- When a persistent business model and a DAL model have the same name, alias only the business model as `{Name}Entity`, for example `using AccountEntity = Business.Models.Entities.Account;`. Use the DAL model by its unaliased name. Do not introduce a DAL-model alias such as `DalEntity`, `AccountDal`, or an alias identical to its type name, and never use the generic business-model alias `BusinessEntity`.
- Expose optimistic concurrency outside the DAL as an opaque token, normally `string ConcurrencyToken`. For disconnected editing, require the caller to return the token read with the original entity. Re-reading immediately before saving is not optimistic concurrency and permits last-writer overwrite.
