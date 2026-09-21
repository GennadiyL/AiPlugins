---
name: gl-dev-csharp-business
description: Use when implementing or reviewing GL Business.Models, Business.Contracts, domain entities, enums, service contracts, service implementations, business operations, messaging contracts or in-process handlers, DTO records, validation, or domain exceptions.
---

# GL Dev CSharp Business

Keep business behavior and contracts independent of persistence and external-provider mechanics. Apply `gl-dev-csharp-common` to all C# source changes and `gl-dev-csharp-architecture` when changing project boundaries or registrations.

**REQUIRED SUB-SKILL:** Use `gl-dev-csharp-shared` when implementing `Messaging.Contracts`, `Messaging.InProcessBus`, `ISharedContext`, or message publishing from business code.

When placing types inside `Business.Models`, `Business.Contracts`, `Business.Impl`, or their `{DomainN}` equivalents, inspect the current [TemplateSolution asset](../gl-dev-csharp-architecture/assets/TemplateSolution) and read [references/business-project-structure.md](references/business-project-structure.md). The asset is the single source of truth for concrete business project and folder structure; the reference explains placement decisions. Use the regular-domain layout unless the particular implementation explicitly identifies the area as a subdomain.

## Structure and services

- Put business service interfaces in `{Domain}.Contracts/Services`, implementations in `{Domain}.Impl/Services`, and DTOs alongside their corresponding service contracts.
- Construct each service with `ISharedContext` and `I{Project}UnitOfWork`, plus only genuinely needed adapter or operation dependencies.
- When a workflow contains a substantial independent business subflow, extract it into a project-local operation. Co-locate the internal interface, implementation, and DTOs under the owning implementation project's `Operations/{OperationName}` folder, such as `Business.Impl/Operations/{OperationName}` or `{DomainN}.Impl/Operations/{OperationName}`.
- Explicitly declare all service-interface methods and properties `public`.

## Domain models and enums

- Persistent business models derive from `BaseEntity`.
- Use only anemic POCO classes for persistent business models. Keep business behavior in services and operations rather than on the models.
- Every persistent business entity exposes its primary key as `Id`. Prefer `Guid`; `long` is also allowed, but use one key type consistently for all persistent business entities in the solution.
- Store date and time values as UTC by convention; do not add a `Utc` suffix to property names.
- Use only arrays (`T[]`), `List<T>`, `Dictionary<TKey, TValue>`, or `HashSet<T>` as concrete collection types in persistent business models and DTOs. A property may expose `ICollection<T>` backed by one of these concrete types.
- Persistent-business-model collection properties have both `get` and `set` accessors and normally initialize to an empty collection, for example `public ICollection<Employee> Employees { get; set; } = new List<Employee>();`.
- When an entity references a parent, include both the parent foreign-key property and navigation property. The foreign-key type matches the solution's entity key type. Make both properties nullable for an optional relationship and non-nullable for a required relationship. In an agreed one-to-one relationship, retain foreign-key and reference properties on both classes.
- For a child owned by an aggregate root, use a unidirectional relationship: the aggregate root contains the child collection, and the child omits both the parent navigation property and parent foreign-key property. For example, `Invoice` contains `InvoiceLines`, while `InvoiceLine` contains neither `Invoice` nor `InvoiceId`.
- Give every enum member an explicit numeric value. Reserve `0` for undefined or missing values, or for a strongly meaningful default; begin other values at `1`. Preserve existing numeric meanings unless a value must move to reserve `0` for `Undefined`.

## Validation, exceptions, and DTOs

- Validate inputs and use domain exceptions for invalid or exceptional requests. New domain exceptions derive from `BaseException`. If the owning domain already defines a more specific exception base derived from `BaseException`, derive from that established intermediate base. Follow the project-placement rules in [references/business-project-structure.md](references/business-project-structure.md).
- Define DTOs and other auxiliary entities as POCO records, with one record per `.cs` file named exactly after the record. Do not use `Dto`, `Request`, or `Response` suffixes.
- Except for sized-collection allocation, initialize records through properties rather than constructors. Record collection properties are get-only, hold a stable collection instance, and normally initialize to an empty collection, for example `public ICollection<MyClass> MyClasses { get; } = new List<MyClass>();`.
- The only permitted record constructor receives collection sizes and allocates the corresponding collections. For a sized array, store `new MyClass[size]` in a stable get-only property; do not return a new collection from an expression-bodied property.
- Name business inputs after the operation or business action, such as `CreatePendingShowerOrder` or `ConfirmPaymentForOrder`. Name business outputs with an `Info` suffix, such as `CreatePendingShowerOrderInfo` or `ConfirmPaymentForOrderInfo`.
