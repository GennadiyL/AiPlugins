---
name: gl-dev-csharp-tech-ef-core
description: Use when implementing or reviewing EF Core DbContext, DbSet, server-translated LINQ queries, entity persistence, or row-version concurrency in a GL data-access project.
---

# GL Dev CSharp EF Core

Keep EF Core behavior server-translatable and consistent with the data-access contracts. Apply `gl-dev-csharp-common` to C# source and `gl-dev-csharp-data-access` for repository, unit-of-work, and external concurrency-token rules.

- `{Project}DbContext` is the main code-first EF Core `DbContext` and exposes a `DbSet` for every DAL model.
- Write repository queries as LINQ that EF Core can translate. For case-insensitive server-side comparisons, use a translatable normalized comparison rather than `string.Equals(..., StringComparison.OrdinalIgnoreCase)`.
- When optimistic concurrency is required, use a DAL `RowVersion`. Translate it to and from the opaque concurrency token defined by the data-access contract rather than exposing persistence bytes directly.
