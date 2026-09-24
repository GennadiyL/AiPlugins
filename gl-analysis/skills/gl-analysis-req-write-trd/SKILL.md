---
name: gl-analysis-req-write-trd
description: Use when an approved BRD needs a solution-neutral technical requirements document, persistent-model and DTO schemas, or logical API/BFF contracts drafted or revised.
---

# GL Analysis: Write Technical Requirements

Produce or revise `requirements/NNN-feature-name/trd.md`. The TRD defines solution-neutral
contracts for development; it does not design or generate the C# solution.

Before writing, read [the artifact contract](../../references/artifact-contract.md),
[the canonical types](../../references/canonical-types.md),
[the TRD template](../../assets/templates/trd-template.md), the exact approved `brd.md`, applicable
repository policies, and an existing TRD when revising. Stop if the BRD is absent, not Approved, or
its exact version and approval provenance cannot be established. A BRD approval permits drafting
only. Preserve `PM-###`, `DTO-###`, `SVC-###`, and `OP-###` when their meanings persist.

## Draft the contracts

1. Fill every template section. Treat BRD roles, use cases, rules, requirements, and success
   criteria as authoritative and cite their stable IDs instead of redefining business meaning.
   Separate approved facts from proposals, assumptions, and open questions.
2. Define each persistent model's purpose, identifier, canonical-typed properties, separate
   `Required`/`Nullable` state, constraints, relationships/cardinality, lifecycle, concurrency, and
   auditing. When one is not decided, record the contract slot as unresolved; a proposed property,
   canonical type, or nullability must be labeled proposed and is not active. A BRD naming a field
   establishes at most the business concept; it does not by itself approve that field's canonical
   type or nullability. Cite an explicit source for each active type and nullability decision, or
   keep that decision proposed/unresolved.
3. Define separate request, response, or shared DTOs. For every DTO, name consuming `OP-###` IDs and
   give every listed property a canonical type, separate nullability, validation, domain mapping,
   and decision status. Cite or label separately the DTO direction, operation assignment, and each
   exposed field. Defining a DTO does not activate its shape or authorize field exposure. A
   `PM-###` may never be an operation input or output.
4. Group logical operations under `SVC-###`. Each `OP-###` names linked BRD IDs, authorized
   `ROLE-###` IDs, DTO input/output, source-backed validation/domain errors, side effects,
   transaction boundary, idempotency, and optional transport metadata. Mark an undecided item
   unresolved; label an alternative proposed. Never turn a conventional default or pressure-request
   preference into an active contract. A BRD capability such as create, update, or view supports the
   logical operation, not a particular request or response shape. Each input/output selection and
   each returned field needs explicit source support or stays proposed/unresolved.
5. Resolve every TRD reference. Map every BRD use case to one or more operations or explicitly
   classify it as non-system work. Give every protected operation authorization. Give every BRD
   `ROLE`, `UC`, `BR`, `FR`, `NFR`, and `SC` ID a complete traceability row. Partial or unresolved
   coverage cannot be reported as covered.

Do not infer as active requirements a missing identifier representation, property nullability,
lifecycle, concurrency, auditing, identity mechanism, route, transport status, error taxonomy,
retry rule, transaction policy, idempotency policy, load definition, or observability policy.
Record each material gap with affected IDs and decision owner; it blocks approval and development
handoff. Source-backed behavior may remain active while its implementation mechanism stays open.

Keep the TRD solution-neutral. Do not create C# syntax or files, EF attributes/configuration,
repositories, controllers, namespaces, folders, interfaces/classes, projects, solutions, tasks,
tests, or application code. Implementation suggestions may be recorded only as non-authoritative
proposals when requested; they cannot satisfy a contract gap.

## Finish at the gate

Check reference resolution, persistent/DTO separation, the source/status of every property's type
and nullability, the source/status of every operation input/output and exposed field, operation
authorization/errors/effects/transaction/idempotency, and full BRD coverage.
Leave status `Draft` or `In Review` while any material gap exists. A request that says "create and
approve" is not approval of the exact version produced. Approval requires an explicit decision on
that presented version after blockers are resolved. Stop with handoff `Not ready`; do not invoke or
imitate a development skill.

If the feature location is unavailable, present the TRD in the reply and identify the unresolved
save location. Revise contracts in place when meaning persists; use a new ID only for a distinct
contract.
