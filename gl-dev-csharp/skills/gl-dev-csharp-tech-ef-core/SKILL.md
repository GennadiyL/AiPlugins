---
name: gl-dev-csharp-tech-ef-core
description: Use when implementing or reviewing EF Core DbContext, DbSet, server-translated LINQ queries, entity persistence, or row-version concurrency in a GL data-access project.
---

# GL Dev CSharp EF Core

Keep EF Core behavior server-translatable and consistent with the data-access contracts. Apply `gl-dev-csharp-common` to C# source and `gl-dev-csharp-data-access` for repository, unit-of-work, and external concurrency-token rules.

- `{Project}DbContext` is the main code-first EF Core `DbContext` and exposes a `DbSet` for every DAL model.
- Write repository queries as LINQ that EF Core can translate. For case-insensitive server-side comparisons, use a translatable normalized comparison rather than `string.Equals(..., StringComparison.OrdinalIgnoreCase)`.
- When optimistic concurrency is required, use a DAL `RowVersion`. Translate it to and from the opaque concurrency token defined by the data-access contract rather than exposing persistence bytes directly.

## DbContext lifetime and tracking

- For SQLite and SQL Server, use a short-lived `DbContext` per unit of work, normally one scoped instance per API call. Share that instance across repositories participating in the same operation; dispose it when the scope ends.
- Never register `DbContext` as a singleton or preload the whole database into its change tracker as an application cache. A context is not thread-safe; await operations sequentially on a shared context. For background jobs or independent operations outside a request scope, create and dispose a context through `IDbContextFactory` or an explicit DI scope.
- Load only the required rows and columns. Use `AsNoTracking()` for read-only entity queries. Use tracking for entities being changed within the unit of work, or explicitly attach changes according to the existing disconnected repository and concurrency contracts. Do not assume changes to no-tracking results are saved automatically.
- For write and read/write operations with pending tracked changes, call the unit of work's `SaveChanges` or `SaveChangesAsync` after successful business validation and before returning success. The business-operation boundary controls saving; do not save independently inside every repository method. Read-only operations do not require a save. `AcceptAllChanges()` only updates tracker state; it does not persist data. Save related changes atomically; use an explicit transaction when one business operation requires multiple saves.
- Consider context pooling only after measuring allocation overhead. Pooling reuses reset contexts; it does not provide a shared entity cache. For SQLite, keep write transactions short because only one writer can write at a time.

## Transaction isolation

- Use `ReadCommitted` isolation for write and read/write transactions where supported. Keep optimistic-concurrency checks; this isolation level does not replace them.
- Use `Snapshot` isolation for read-only transactions when supported and enabled. On SQL Server, this requires `ALLOW_SNAPSHOT_ISOLATION ON`. `READ_COMMITTED_SNAPSHOT` alone provides statement-level snapshots under `ReadCommitted`, not a transaction-wide `Snapshot` view.
- If snapshot isolation is unavailable, document the provider-supported fallback and its consistency guarantees. When a consistent view across multiple reads is required, preserve that requirement with an appropriate supported isolation level rather than silently weakening it.
- SQLite provider exception: use supported `Serializable` transactions instead of requesting unsupported `Snapshot` isolation. Microsoft.Data.Sqlite promotes `ReadCommitted` to `Serializable`. In WAL mode, SQLite read transactions see a snapshot; record the journal-mode assumption when relying on that behavior. Keep read-only transactions free of writes.

## Code First Ex: EF schema export and SQL migrations

Code First Ex means exporting the EF model to schema SQL and deriving reviewed incremental SQL scripts from successive snapshots. Run the workflow manually or with AI assistance through PowerShell commands. The persistent EF models and their mappings remain the single source of truth for the desired schema; SQL snapshots are generated records and migration scripts describe how to reach that schema while preserving or intentionally transforming data. Do not replace an established migration workflow without task authorization.

1. For each database provider, generate and preserve an initial complete schema, such as `mssql_000_initial_structure.sql` or `sqlite_000_initial_structure.sql`. This is the baseline for the first change. For later changes, use the snapshot belonging to the preceding migration version as the baseline.
2. After changing the model or mappings, export the new complete schema from PowerShell with `dotnet ef dbcontext script --output <new-schema.sql>`. Select the appropriate project, startup project, and context as needed. The configured provider determines the SQL dialect. This bypasses C# migrations and generates creation SQL, not an incremental upgrade script. Name the new snapshot using the convention below.
3. Compare the old and new schema and generate a separate delta SQL script using one of these options:
   - **AI:** Supply both schemas, the database engine/version, and explicit intent for renames, conversions, defaults, and backfills. Do not infer data-preserving transformations solely from structural differences.
   - **Atlas:** Use `atlas schema diff --from file://<old-schema.sql> --to file://<new-schema.sql> --dev-url <disposable-dev-database-url>` and save its SQL output. For SQLite, an in-memory dev URL is `sqlite://file?mode=memory`. Basic SQLite tables, indexes, keys, and constraints are available in the open edition; SQL Server and advanced objects can require Pro. Verify current feature availability before choosing it.
   - **Microsoft Schema Compare:** For SQL Server, import/build schemas into SQL projects or `.dacpac` files, or create disposable databases for comparison, then generate an update script. It does not directly compare two standalone SQL files and does not support SQLite.
4. Review the delta and test it against the previous database version with representative data. Verify the resulting schema, constraints, and preservation or intended transformation of existing data. A successful execution alone is insufficient.
5. Store the reviewed migration and matching snapshot together in the project's schema-script folder and include both in version control. Keep applied migrations and their snapshots immutable. Apply reviewed scripts manually from PowerShell or through an established SQL-script runner, recording the applied version and handling transaction failures. A dedicated automated runner is optional. Execute the initial-structure script only for an empty database, then apply incremental migration scripts in version order. Snapshots are comparison/reference artifacts and must not be executed as upgrades against populated databases. Use the exact reviewed and tested scripts.

### File naming and ordering

Use the real provider prefix `mssql` or `sqlite`, followed by the change date in `yyyyMMdd` format and a zero-padded sequence for changes on the same date. Both files in a change pair share the same prefix, date, and sequence. Use these default names:

```text
mssql_000_initial_structure.sql
mssql_20260917_001_migration.sql
mssql_20260917_001_snapshot.sql
mssql_20260917_002_migration.sql
mssql_20260917_002_snapshot.sql
sqlite_000_initial_structure.sql
sqlite_20260917_001_migration.sql
sqlite_20260917_001_snapshot.sql
```

The `000` initial marker sorts before dated changes; it is not a date. Sort by filename ascending: provider first, then date and sequence, with each migration/snapshot pair adjacent. Use the actual change date, allocate sequences monotonically within that date, and do not backdate changes ahead of applied versions. Project-specific names may differ only if they preserve provider identification, change date, unambiguous execution order, and adjacency of each pair. The alphabetical position of the snapshot within its pair does not make it an executable migration.

When Code First Ex is selected, use its SQL scripts and applied-version record for schema upgrades. The template's `Database.MigrateAsync()` helpers apply EF C# migrations and do not execute these standalone SQL files. Use those helpers only for projects retaining EF C# migrations. Do not use `EnsureCreated()` to bypass the selected initial-structure script and version record.

Keep schema snapshots and migration scripts separate for SQLite and SQL Server. A schema delta does not transfer existing data between providers. Standard `dotnet ef migrations script` is an alternative when retaining EF C# migrations; it does not calculate a delta between arbitrary SQL files.

Sources: [EF schema export](https://learn.microsoft.com/en-us/ef/core/cli/dotnet#dotnet-ef-dbcontext-script), [Atlas schema diff](https://atlasgo.io/declarative/diff), [Microsoft Schema Compare](https://learn.microsoft.com/en-us/sql/tools/sql-database-projects/concepts/schema-comparison).

Isolation references: [SQL Server snapshot isolation](https://learn.microsoft.com/en-us/sql/connect/ado-net/sql/snapshot-isolation-sql-server), [Microsoft.Data.Sqlite transactions](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/transactions), [SQLite isolation](https://www.sqlite.org/isolation.html).
