# Data-access structure

Use these names as solution folders and projects. The physical project folders may remain flat, as defined by `gl-dev-csharp-architecture` and its `TemplateSolution` asset.

```text
DataAccess/
|-- DataAccess.Contracts
|-- DataAccess.EntityFramework
|-- DataAccess.EntityFramework.MsSql
|-- DataAccess.EntityFramework.SqLite
|-- DataAccess.Dapper
`-- DataAccess.Dapper.SqLite
```

## Standard placement

- `DataAccess.Core` contains persistence-neutral abstractions shared across domains: `IDalEntity`, `IMapper`, `IRepository<T>`, `IUnitOfWork`, `IUnitOfWorkTransaction`, `IQuery`, and `ICommand`.
- `DataAccess.Core.EntityFramework` contains provider-independent EF Core base implementations shared across domains, including `Repository<TContext, TBusiness, TDal>`, `UnitOfWork<TContext>`, and `UnitOfWorkTransaction`. It may depend on EF Core and `DataAccess.Core`, but not on a business domain or database provider.
- `DataAccess.Contracts` contains application-specific repository and unit-of-work contracts.
- `DataAccess.EntityFramework` contains provider-neutral EF Core repositories, mappings, and DAL persistence models.
- `DataAccess.EntityFramework.MsSql` and `DataAccess.EntityFramework.SqLite` contain provider-specific EF Core configuration.
- `DataAccess.Dapper` contains provider-neutral Dapper data-access behavior.
- `DataAccess.Dapper.SqLite` contains SqLite-specific Dapper behavior and configuration.

## Compact single-domain placement

A small, single-domain solution may omit the `Core` projects. In that case, place `IDalEntity`, `IMapper`, `IRepository<T>`, `IUnitOfWork`, `IUnitOfWorkTransaction`, `IQuery`, and `ICommand` in `DataAccess.Contracts`. This is an alternative layout, not duplication of the abstractions in both projects.

## Domain-specific placement

For a large business domain, group its DAL projects under the `DataAccess/{Domain}` solution folder and retain the domain in each project name, such as `{Domain}.DataAccess.Contracts`, `{Domain}.DataAccess.EntityFramework`, and `{Domain}.DataAccess.EntityFramework.MsSql`.

## Repository, query, and command placement

- Put repository interfaces in the applicable `{Scope}.DataAccess.Contracts/Repositories` project-internal folder.
- Put repository implementations in the corresponding technology project, such as `{Scope}.DataAccess.EntityFramework/Repositories`.
- Put query and command contracts in the applicable contracts project. Put their implementations in the technology project that performs the database operation.
- Keep DAL persistence models in the technology-neutral implementation project when they are shared by provider-specific projects; for EF Core, use `{Scope}.DataAccess.EntityFramework/Models`.
