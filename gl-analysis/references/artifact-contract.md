# GL Analysis artifact contract

One invocation concerns one feature folder: `requirements/NNN-feature-name/`. Preserve existing
feature numbering and naming when updating a feature; choose the next available `NNN` for a new one.
Its working `discovery.md`, authoritative `brd.md` and `trd.md`, and review checklists remain distinct.

## Authority and status

| Artifact | Authority |
| --- | --- |
| `discovery.md` | Working record of raw input, alternatives, assumptions, questions, and decisions; never an implementation source. |
| Approved `brd.md` | Authority for business scope, roles, use cases, rules, and outcomes. |
| Approved `trd.md` | Authority for technical requirements and solution-neutral contracts, subject to the approved BRD. |

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

Stable identifiers use `ROLE-###` for roles, `UC-###` for use cases, `BR-###` for business rules,
`FR-###` for functional requirements, `NFR-###` for non-functional requirements, `SC-###` for
success criteria, `PM-###` for persistent models, `DTO-###` for data transfer objects, `SVC-###`
for logical services, and `OP-###` for service operations. Keep an ID stable when its meaning
persists; use a new ID for a distinct item. Discovery notes need no authoritative IDs.

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
