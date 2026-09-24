---
name: gl-analysis-req-workflow
description: Use when the user explicitly requests coordination of the GL Analysis requirements workflow, its gated phases, or a requirements-to-development handoff readiness decision.
---

# GL Analysis: Requirements Workflow

Coordinate one feature without authoring phase artifacts. The sole write exception is recording a
current user's valid exact-version approval metadata under the shared contract. Read
[the artifact contract](../../references/artifact-contract.md), inspect the feature folder, and use
the recorded artifact versions, statuses, approval provenance, promotion decisions, and latest
review results. Never infer an approval from urgency, silence, an unavailable owner, or a request to
continue.

## Record approval before routing

Before choosing a route, inspect the current request for an explicit approval of an exact existing
`discovery.md`, `brd.md`, or `trd.md` version. Only when the request supplies the approver identity,
decision date, approval scope, source, and any authorization required by repository policy:

1. Record only status `Approved`, the approval decision, and its provenance in that same artifact.
   Do not change its version, substantive content, stable IDs, or any other artifact.
2. Re-inspect the resulting artifact state and downstream prerequisites.
3. If the same request asks to continue, route exactly one next phase whose gates now pass. If it
   does not, report the recorded approval and stop.

This metadata action is not a phase route. If any required evidence is absent, do not write or infer
it; report the missing field and stop at the approval action. Treat discovery promotion as a
separate decision. Approval of one artifact never records or implies approval of another.

## Route one phase

The only phase routes are:

- `$gl-analysis-req-discover`
- `$gl-analysis-req-write-brd`
- `$gl-analysis-req-clarify`
- `$gl-analysis-req-write-trd`
- `$gl-analysis-req-review`

Choose exactly one route per invocation. Invoke the named phase skill when it can run now; do not
reproduce or approximate its artifact content inside this coordinator. If skill invocation is not
available, name the route and stop. When the user explicitly requests one named phase, validate only
that phase's prerequisites and preserve its scope. If they are unmet, report the prerequisite and
recommended route; do not silently run the full workflow.

Use the earliest applicable row:

| Observed state | Allowed route or stop |
| --- | --- |
| `discovery.md` absent | Route `$gl-analysis-req-discover`. |
| Discovery has a discovery-owned ambiguity explicitly classified as blocking a safe BRD draft or the promotion decision | Route `$gl-analysis-req-clarify` against discovery. |
| Discovery is not Approved or has no qualifying discovery-to-business promotion decision | Stop for the exact missing approval/decision; broad discovery work may route to `$gl-analysis-req-discover`. |
| Discovery is Approved, promotion is established, and `brd.md` is absent or needs an authorized revision | Route `$gl-analysis-req-write-brd`. |
| BRD exists with a material business ambiguity | Route `$gl-analysis-req-clarify` against the BRD. |
| BRD is Draft/In Review but has no material ambiguity | Stop for explicit approval of that exact BRD version. |
| Exact BRD version is validly Approved and `trd.md` is absent or needs an authorized revision | Route `$gl-analysis-req-write-trd`. |
| TRD exists with a material technical-contract ambiguity | Route `$gl-analysis-req-clarify` against the TRD. |
| TRD is Draft/In Review but has no material ambiguity | Stop for explicit approval of that exact TRD version. |
| Exact TRD version is validly Approved and review is missing or stale | Route `$gl-analysis-req-review`. |
| Current review fails | Stop on its findings; recommend one owning write or clarification phase for an explicitly authorized controlled revision, then require re-approval and re-review. |
| Current review passes every gate and declares handoff Ready | Recommend a separate user-invoked `gl-dev-csharp-*` workflow with the approved handoff package. |

The discovery-clarification row applies only to discovery-owned blockers. Questions that discovery
classifies as safe to remain explicitly labeled in a Draft BRD do not intercept routing after valid
discovery approval and promotion. When that gate is valid and `brd.md` is absent, the earliest
applicable route is `$gl-analysis-req-write-brd`; the BRD then owns its labeled business questions.

Approval gates are independent. Discovery approval does not approve the BRD; BRD approval does not
approve the TRD; labels alone do not replace exact-version approval provenance. Clarification never
creates a missing artifact or edits a different artifact. A change after approval requires the
phase skill's controlled revision and invalidates downstream approval or review that depended on
the changed version.

## Report and stop

After the selected route completes or a gate blocks progress, report:

- current phase;
- whether approval metadata was recorded, with exact artifact version and provenance, or why it was
  not recorded;
- each existing artifact's path, exact version, status, and approval evidence;
- exact missing artifact, decision, clarification, or failed review gate;
- the one next allowed phase skill or approval action;
- later phases that remain prohibited.

Never invoke, simulate, or generate output for `gl-dev-csharp-*`. Do not create C# solutions,
projects, files, interfaces, classes, EF configuration, tasks, tests, or application code. A handoff
recommendation is allowed only when the BRD and TRD are validly Approved and the current review has
complete traceability, passing mandatory checks, zero Blockers, zero Important findings, and a
`Ready` decision. Name only the approved `brd.md`, approved `trd.md`, and passing review results as
the handoff package; discovery remains supporting context.
