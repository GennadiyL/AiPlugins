---
name: gl-analysis-req-clarify
description: Use when an existing discovery.md, brd.md, or trd.md has material ambiguity, unresolved decisions, contradictions, or requirements that are not testable enough for their next approval gate.
---

# GL Analysis: Clarify Requirements

Resolve material ambiguity in exactly one existing requirements artifact. An accepted answer changes
the requirement it owns; it does not authorize another artifact or implementation.

Before acting, read [the artifact contract](../../references/artifact-contract.md), the one active
`discovery.md`, `brd.md`, or `trd.md`, and its cited sources. Do not create an artifact that is
missing. Route creation to `gl-analysis-req-discover`, `gl-analysis-req-write-brd`, or
`gl-analysis-req-write-trd` after that skill's prerequisites are met.

## Choose the question

1. Find unresolved decisions, conflicts, vague terms, and requirements whose acceptance cannot be
   determined. Classify each by its owner: discovery owns exploratory uncertainty; the BRD owns
   business scope, roles, use cases, rules, outcomes, and business-facing expectations; the TRD owns
   solution-neutral models, DTOs, service contracts, errors, and technical qualities.
2. Work only in the active artifact. If an ambiguity is owned by another artifact, do not ask or
   apply it here. Report the ownership mismatch. Route a later controlled clarification turn to the
   existing owning artifact; if it is missing, route creation to its writing skill. Do not create,
   open, or edit that artifact in the current turn. Report downstream impact without mirroring an
   answer into another artifact.
3. Prioritize ambiguity by its effect on scope, acceptance, implementation feasibility, then
   testability. Ask exactly one decision unit per turn: one rule or contract that can be accepted or
   rejected as a whole. Request a complete rule, including inseparable boundary behavior, rather
   than joining independently answerable subquestions. Do not combine separate policies or apply a
   suggested, conventional, or "sensible" default. A context-supported recommendation may
   accompany the request only when labeled non-authoritative; it remains unresolved until accepted.

## Apply an answer

On a later turn, first decide whether the answer explicitly resolves the decision unit. If it is
partial, tentative, conflicting, or merely exploratory, ask one focused follow-up and make no
artifact or clarification-log change.

Before changing an `Approved` artifact, establish a controlled revision of that same artifact with
a new version and status `Draft` or `In Review`. Preserve the prior approved version, approver,
approval date, and scope as provenance, and state that its approval does not cover the modified
version. If a controlled revision cannot be established, do not change the approved content.

For an accepted answer:

1. Update the existing requirement, rule, use case, schema, or contract in place. Preserve its stable
   ID and trace links, remove superseded ambiguity and contradictory active wording, and do not add a
   second statement of the same requirement.
2. Append one entry to that artifact's `## Clarification Log` with the date, exact question, accepted
   answer, affected IDs, and source. The log records provenance; the updated item remains the only
   active requirement definition.
3. Reassess the same artifact. Ask exactly one next highest-impact question, or state that no material
   ambiguity remains. Stop if the user ends the session.

Do not create or edit a second artifact, claim approval, design C# types or architecture, generate
tasks or tests, or write code. A conflict in a downstream approved artifact requires its own
controlled revision.
