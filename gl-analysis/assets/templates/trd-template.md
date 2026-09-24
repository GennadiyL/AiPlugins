# Technical Requirements Document: [Feature Name]

## Document Control and BRD Reference

- TRD version: [version]
- Status: [Draft | In Review | Approved | Superseded]
- Date: [YYYY-MM-DD]
- Exact approved BRD source: [path, version, status, approver, approval date]
- TRD owner and intended approver: [owner / approver]
- Revision basis: [new draft or prior TRD version]

Approval applies only to the exact version presented. An approved BRD authorizes TRD drafting; it
does not approve this TRD or authorize development.

## Technical Scope and Constraints

- In scope: [solution-neutral contracts derived from BRD IDs]
- Out of scope: [implementation and architecture ownership]
- Approved technical constraints: [constraint, source, affected IDs]
- Proposed constraints: [proposal, rationale, affected IDs]
- Unresolved constraints and blockers: [question, owner, affected IDs]

## Role and Use-Case Traceability

| BRD role/use case | Business meaning retained from BRD | Technical operation or non-system classification | Authorization source | Status/notes |
| --- | --- | --- | --- | --- |
| [ROLE/UC ID] | [BRD reference, not a redefinition] | [OP-### or explicit non-system work] | [BRD ID] | [resolved/proposed/unresolved] |

## Persistent Model Schemas

### PM-### — [Logical model name]

- Purpose and source: [BRD IDs]
- Identifier: [property and canonical type, or explicit unresolved/proposed decision]
- Relationships and cardinality: [approved/proposed/unresolved, source]
- Lifecycle: [approved/proposed/unresolved, source]
- Concurrency: [approved/proposed/unresolved, source]
- Auditing: [approved/proposed/unresolved, source]

| Property | Canonical type | Nullability | Constraints | Source / decision status |
| --- | --- | --- | --- | --- |
| [name] | [canonical type] | [Required or Nullable] | [constraint] | [BRD ID, approved/proposed/unresolved] |

Every listed property has a canonical type and separate nullability. A proposed schema element is
not active until accepted. A BRD naming a field does not by itself approve its canonical type or
nullability; each active decision needs an explicit source. Do not use a persistent model as a
service input or output.

## DTO Schemas

### DTO-### — [Logical DTO name]

- Direction: [request | response | shared]
- Consuming operations: [OP-###]
- Purpose and source: [BRD IDs]

| Property | Canonical type | Nullability | Validation | Field-to-domain mapping | Source / decision status |
| --- | --- | --- | --- | --- | --- |
| [name] | [canonical type] | [Required or Nullable] | [rule] | [PM property or logical concept] | [BRD ID, approved/proposed/unresolved] |

Record source/decision status separately for direction, consuming-operation assignment, each
canonical type, each nullability decision, and every exposed field. Defining a DTO does not make its
shape active.

## API/BFF Service Contracts

### SVC-### — [Logical service name]

- Purpose: [business capability and BRD IDs]

#### OP-### — [Logical operation name]

- Linked BRD use cases and requirements: [UC/BR/FR/NFR/SC IDs]
- Authorized roles: [ROLE IDs and authorization-rule source]
- Input: [DTO-### or None; explicit source plus approved/proposed/unresolved status]
- Output: [DTO-### or None; explicit source plus approved/proposed/unresolved status]
- Validation and domain errors: [source-backed errors; proposed/unresolved details labeled]
- Side effects: [source-backed effects; proposed/unresolved details labeled]
- Transaction boundary: [approved/proposed/unresolved]
- Idempotency: [approved/proposed/unresolved]
- Optional transport metadata: [approved/proposed/unresolved/none]

All references must resolve. Each protected operation names authorization. Persistent models are
never operation inputs or outputs. A create, update, or view capability does not itself approve an
input shape, response shape, or exposed field; unsupported selections stay proposed/unresolved.

## Validation and Error Contracts

| Contract/error | Applies to | Trigger or rule | Observable result | Source / decision status |
| --- | --- | --- | --- | --- |
| [name] | [PM/DTO/OP IDs] | [condition] | [solution-neutral outcome] | [BRD ID, approved/proposed/unresolved] |

Do not invent an error taxonomy, detailed error code, or transport status as an active requirement.

## Security and Authorization

| Protected operation | Authorized role(s) | Ownership/scope rule | Source | Unresolved enforcement decisions |
| --- | --- | --- | --- | --- |
| [OP-###] | [ROLE-###] | [rule] | [BRD ID] | [identity/authentication/authorization gaps] |

## Data and Integration Requirements

- Data ownership and persistence needs: [source and status]
- Identifier representation: [approved/proposed/unresolved]
- Relationships and lifecycle: [approved/proposed/unresolved]
- External integrations: [approved/proposed/unresolved/none identified]
- Storage, mapping, and migration constraints: [approved/proposed/unresolved]

## Performance, Reliability, and Observability

| Requirement | Technical contract | Measurement context | Status/blocker |
| --- | --- | --- | --- |
| [NFR/SC ID] | [solution-neutral behavior] | [load, percentile, interval, boundary] | [resolved/proposed/unresolved] |

## Assumptions and Open Technical Questions

| Item | Type | Affected IDs | Decision owner | Approval/handoff impact |
| --- | --- | --- | --- | --- |
| [statement/question] | [assumption/proposal/open question] | [IDs] | [owner] | [blocking/non-blocking and why] |

## Complete Traceability Matrix

| BRD ID | TRD ID(s) / section | Coverage | Notes |
| --- | --- | --- | --- |
| [ROLE/UC/BR/FR/NFR/SC ID] | [PM/DTO/SVC/OP ID or section] | [covered/partial/non-system/unresolved] | [source-status detail] |

Every BRD role, use case, business rule, functional requirement, non-functional requirement, and
success criterion receives a row. Every TRD reference resolves.

## Development Handoff Readiness

- Readiness: [Ready | Not ready]
- Blocking decisions: [open item and affected IDs]
- Mandatory contract checks: [reference resolution, DTO separation, typing/nullability,
  authorization, errors, effects, transaction/idempotency, traceability]
- Handoff package when ready: approved BRD, approved TRD, and passing review results

GL Analysis stops here. It does not create or place C# projects, files, interfaces, classes,
repositories, Entity Framework configuration, tests, tasks, solutions, or application code.

## Approval

- Current decision: [Not submitted | Changes requested | Approved | Rejected]
- Exact TRD version reviewed: [none/not applicable when Not submitted; version only after actual submission or review]
- Approver: [name/role]
- Decision date: [YYYY-MM-DD]
- Approval scope and conditions: [scope]

Leave the document `Draft` or `In Review` until the exact version receives explicit approval and no
material blocker remains. Approval of another artifact or a request to draft this TRD is not TRD
approval. When the current decision is `Not submitted`, no version has been reviewed; record the
reviewed version only after actual submission or review.
