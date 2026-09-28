# GL Analysis artifact contract

One invocation concerns one feature folder: `requirements/NNN-feature-name/`. Preserve existing
feature numbering and naming when updating a feature; choose the next available `NNN` for a new one.
Its working `discovery.md`, authoritative `brd.md` and `trd.md`, and review checklists remain distinct.

## Authority and status

| Artifact | Authority |
| --- | --- |
| `discovery.md` | Working record of raw input, alternatives, assumptions, questions, and decisions; never an implementation source. |
| Approved `brd.md` | Authority for business scope, roles, Business Capabilities, rules, and outcomes. |
| Approved `trd.md` | Authority for Detailed Use Cases, technical requirements, and solution-neutral contracts, subject to the approved BRD. |

Use `Draft`, `In Review`, `Approved`, or `Superseded` as artifact status. A status of `Approved` applies
only to the artifact and version presented for approval. Discovery approval does not approve a BRD;
BRD approval does not approve a TRD. When sources disagree, surface the conflict for resolution;
do not silently promote working notes over an approved BRD or TRD.

### Approval-state ownership

The workflow coordinator has one metadata-only write exception. When the current user explicitly
approves an exact existing `discovery.md`, `brd.md`, or `trd.md` version and supplies the approver
identity, decision date, approval scope, and source, the coordinator may record only that decision,
status `Approved`, and its approval provenance in that same artifact. Apply any stricter repository
authorization policy.
Do not infer a missing version, approver, date, scope, source, or authorization; stop and request the
missing evidence instead.

This exception cannot change substantive content, stable IDs, or the artifact version, and cannot
edit another artifact. Record the approval metadata before evaluating downstream prerequisites. If
the same request also asks to continue and the updated state satisfies the next gate, the coordinator
may then route exactly one phase skill in that invocation. The metadata write is not a phase route.
Approval of discovery never approves a BRD, and approval of a BRD never approves a TRD; a promotion
decision is also separate from artifact approval.

## Identifiers

Stable identifiers use `ROLE-###` for roles, `BC-###` for BRD Business Capabilities, `UC-###-##`
for TRD Detailed Use Cases, `BR-###` for business rules, `FR-###` for functional requirements,
`NFR-###` for non-functional requirements, `SC-###` for success criteria, `PM-###` for persistent
models, `DTO-###` for data transfer objects, `SVC-###` for logical services, and `OP-###` for
service operations. The middle number of a Detailed Use Case identifies its parent capability and
the final number identifies one action-level scenario within it. Keep an ID stable when its meaning
persists; use a new ID for a distinct item. Discovery notes need no authoritative IDs.

`BC` means Business Capability, never Business Case. A business case is an investment
justification and is not the artifact defined by this contract.

A Business Capability describes a high-level business ability and intended outcome; it may include
several user actions and alternative paths. A Detailed Use Case describes one specific action or
user goal, its observable result, and meaningful alternatives. Do not duplicate each capability as
one equally broad use case. Keep detailed scenarios in the TRD beside the logical operations they
use, while the BRD retains business scope, roles, policies, requirements, and success criteria.

Use this traceability chain:

```text
Business Capability -> Detailed Use Case -> API/BFF Operation -> Test Scenario
```

An API/BFF operation is a logical contract, not necessarily an HTTP, remote, public, or cloud
operation. Every in-scope capability maps to one or more Detailed Use Cases. Every Detailed Use
Case maps to the operations required for its behavior or explicitly identifies justified
local/UI-only or non-system work. Each operation links back to its use cases and applicable BRD
requirements. Main and alternative flows provide identifiable manual-test scenarios with expected
results. Preserve mappings for roles, rules, functional requirements, non-functional requirements,
and success criteria; the BC/UC distinction does not replace them.

When migrating an existing identifier scheme, preserve meaning and record an explicit old-to-new
mapping. A legacy high-level `UC-003` may become `BC-003`, with specific scenarios assigned
`UC-003-01`, `UC-003-02`, and so on. Inspect the legacy item's meaning first; do not relabel an
already detailed use case as a capability.

## Artifact responsibilities

| Artifact or section | Responsibility |
| --- | --- |
| Discovery | Inputs, decisions, alternatives, assumptions, and open questions. |
| BRD | Business Capabilities, scope, rules, outcomes, and business acceptance criteria. |
| TRD Detailed Use Cases | Action-level scenarios, alternatives, expected results, parent capability, and operation links. |
| TRD API/BFF contracts | Inputs/outputs, validation, authorization, effects, transaction/concurrency, and retry semantics. |
| TRD schemas | Persistent models and separate DTO contracts with explicit decision status. |
| Verification artifacts | Concrete manual/automated tests and execution results linked to scenarios. |

Detailed Use Cases can specify reproducible preconditions, actions, and expected results without
claiming that they are executed test evidence or complete test procedures with concrete fixtures.
Persistent models remain distinct from API DTOs. BRD approval does not approve the TRD or authorize
implementation.

## Promotion and handoff

Promote only information whose source and decision status are clear. Keep the original request
separate from interpretation. Label assumptions and questions until resolved. Rejected and deferred
ideas remain visible in discovery; they cannot silently become BRD or TRD requirements. An explicit
discovery-to-business promotion decision permits BRD drafting. It may be recorded in discovery or
given as an explicit current user instruction to create or revise a BRD from approved discovery,
unless a stricter repository policy names a separate authorized promoter. Record the qualifying
source, date, and scope in the BRD. This decision authorizes drafting only; discovery approval alone
does not approve the BRD. Questions about the business problem, scope, decision owner, or core rules block
drafting when no safe draft can represent the gap. Other questions may remain clearly labeled in a
draft BRD for clarification before BRD approval and cannot be treated as approved rules. TRD work
requires an approved BRD. The review phase checks requirements quality and traceability before
handoff.

The development handoff contains only approved `brd.md`, approved `trd.md`, and review results.
`discovery.md` can remain supporting context but cannot directly authorize implementation. GL Analysis
stops at the handoff. It does not create C# solutions or projects, implementation tasks, namespaces,
source placement, interfaces, classes, EF configuration, tests, or application code.
