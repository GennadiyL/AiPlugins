# Requirements Discovery: [Feature Name]

## Status and Sources

- Feature folder: `requirements/NNN-feature-name/`.
- Version: [Exact artifact version.]
- Status: [Draft | In Review | Approved | Superseded]. Discovery remains non-authoritative at every
  status; Approved means only that this exact version is accepted as the discovery record.
- Approval decision: [None recorded, or the explicit decision for this exact version.]
- Approval provenance: [Approver identity, decision date, scope, and source; do not infer a missing
  field.]
- Separate discovery-to-business promotion decision: [Decision, authorized promoter, date, scope,
  and source; otherwise "None recorded here". Promotion is not discovery or BRD approval.]
- Source references: [Identify user messages, notes, documents, and dates; mark absent sources.]
- Authority: This record alone cannot approve a BRD or authorize TRD, C# design, tasks, or code.
  A recorded promotion decision or an explicit current user instruction to create or revise a BRD
  from approved discovery permits drafting, unless repository policy names a separate authorized
  promoter. Record its source, date, and scope in the BRD. Only an approved BRD becomes
  business-requirements authority. Unresolved or rejected material cannot be consumed by development.

## Original Request

> [Preserve the user's actual wording verbatim, or link to an immutable source.]

## Problem or Opportunity

[Interpretation, explicitly labeled as such. Note what is unknown.]

## Intended Outcomes

[Desired outcomes stated by the source; label any inferred outcome as an assumption.]

## Stakeholders

[Named stakeholders and source. Mark missing roles as open questions, not established facts.]

## Raw Ideas

[List ideas as proposed, with source and status; do not promote them to requirements here.]

## Alternatives Considered

[List alternatives and tradeoffs if supplied. Otherwise state that alternatives are not yet known.]

## Assumptions

[Explicit assumption, basis, and confirmation needed. Never present an assumption as a decision.]

## Open Questions

[Prioritize material unknowns. Mark whether each blocks a safe BRD draft or can remain recorded for
clarification before BRD approval. Ask one highest-impact question at a time when interaction is
needed.]

## Decisions and Rationale

[Record only explicit decisions, who made them, when, and why. Otherwise: None recorded.]

## Rejected Ideas

[Record explicit rejections and rationale; otherwise: None recorded.]

## Deferred Topics

[Record explicitly deferred issues, owner, and trigger for revisiting if known.]

## Promotion Readiness

- Ready to seek a discovery-to-business promotion decision: [Yes/No, with reason. Discovery status
  or approval alone does not approve a BRD.]
- Questions blocking a safe BRD draft: [Identify gaps in the business problem, scope, decision owner,
  or core rules when no safe draft can represent them; otherwise state none.]
- Questions that may remain in a draft BRD: [List clearly labeled clarifications to resolve before
  BRD approval; they are not approved rules.]
- Promotion decision reference: [Repeat or link the separate promotion decision in Status and
  Sources. A later explicit user request may supply it, subject to repository policy.]
- Next recommended phase: [Continue discovery, seek a promotion decision, or draft a BRD after a
  qualifying decision. That decision does not approve the BRD. Never begin TRD or C# implementation
  from this artifact.]
