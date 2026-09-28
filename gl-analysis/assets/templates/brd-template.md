# Business Requirements Document: [Feature Name]

## Document Control

- Feature folder: `requirements/NNN-feature-name/`.
- Artifact: `brd.md`.
- Status: Draft. A draft is not approved or authorized for TRD or development.
- Version and date: [Record the version and date.]
- Discovery source and version: [Link the approved `discovery.md`.]
- Discovery-to-business promotion decision: [Cite either the recorded discovery decision or the
  explicit current user instruction to create or revise this BRD from approved discovery. Record
  source, date, and scope; if repository policy names a separate authorized promoter, cite that
  promoter's decision. This permits drafting only and is not BRD approval.]
- Other approved source decisions: [Cite the decision, owner, and date; otherwise state none.]
- Business owner and intended approver: [Name or mark unresolved.]

## Executive Summary

[Summarize the approved business need, intended result, and decisions still needed. Distinguish
source facts from proposed interpretation.]

## Business Problem or Opportunity

[State the current problem and affected people using approved source facts. Identify missing evidence
or unresolved questions rather than supplying plausible values.]

## Objectives and Success Measures

| ID | Business objective | Measure and calculation | Baseline/source | Target and timeframe | Evidence owner/status |
| --- | --- | --- | --- | --- | --- |
| SC-001 | [Approved objective] | [Observable metric, unit, numerator/denominator if applicable] | [Value or unresolved] | [Value/date or unresolved decision] | [Owner; approved or proposed] |

[A metric with an unresolved target remains a draft success criterion and a BRD approval question.]

## Stakeholders and Roles

| ID | Role or stakeholder | Business responsibility | Source/decision status |
| --- | --- | --- | --- |
| ROLE-001 | [Name] | [Responsibility] | [Approved source] |

## Scope

### In Scope

[List included business activities and outcomes with approved source references.]

### Out of Scope

[List exclusions and their source. Keep rejected and deferred ideas separate from requirements.]

## Current and Target Business Process

- Current process: [Known steps and pain points; mark unknown steps as unresolved.]
- Target process: [Business steps, participating roles, and decision points; do not design a system.]
- Process gap or decision: [Question, owner, and consequence if unresolved.]

## Business Rules

| ID | Rule or unresolved rule | Source/status | Related capabilities and requirements |
| --- | --- | --- | --- |
| BR-001 | [Testable business policy, or clearly marked unresolved decision] | [Approved decision or unresolved question] | [BC-###; FR-###] |

[Do not assign a rule value or threshold that the business has not decided.]

## Business Capabilities

### BC-001 — [High-level business ability]

- Outcome: [Observable intended business result.]
- Scope, priority, and source: [Included ability, priority if decided, and approved source.]
- Participating roles: [ROLE-### and responsibility.]
- High-level flow: [Concise business progression; do not describe every click, screen, or API.]
- Meaningful alternatives: [High-level rejection or alternate outcomes supported by requirements.]
- Linked requirements: [BR-###, FR-###, NFR-###, SC-### as applicable.]
- Acceptance examples:
  - Given [business condition], when [capability is exercised], then [observable outcome].
  - Given [meaningful alternative], when [action occurs], then [observable business result].

[Repeat the structure for each capability. A capability may contain several action-level scenarios.
Reserve `UC-###-##` Detailed Use Cases and their operation links for the TRD.]

## Functional Requirements

| ID | Business capability and verifiable outcome | Priority/status | Source | Linked capabilities and rules |
| --- | --- | --- | --- | --- |
| FR-001 | [The business must be able to...] | [Priority; approved or proposed] | [Approved source] | [BC-###; BR-###] |

## Business-Facing Non-Functional Requirements

| ID | Measurable business expectation | Measure/target/status | Source | Linked capabilities |
| --- | --- | --- | --- | --- |
| NFR-001 | [Accessibility, timeliness, retention, or other business expectation] | [Unit, target, or unresolved decision] | [Approved source or proposed] | [BC-###] |

[Use “none established” when the sources provide no business-facing expectation. Do not introduce
technology, architecture, endpoint, or storage decisions.]

## Assumptions and Dependencies

### Facts and decisions

| Statement | Source | Decision owner/date, if applicable |
| --- | --- | --- |
| [Approved fact or explicit decision] | [Source] | [Owner/date or not applicable] |

### Assumptions

| Assumption | Basis | Confirmation owner/status | Affected IDs |
| --- | --- | --- | --- |
| [Explicit inference, not a requirement] | [Reason] | [Owner; unresolved] | [IDs] |

### Unresolved business questions

| Question | Decision owner | Impact on draft/approval | Affected IDs |
| --- | --- | --- | --- |
| [Material missing business decision] | [Owner or unresolved] | [What cannot be finalized] | [IDs] |

### Dependencies

| Dependency | Owner/source | Required by | Status |
| --- | --- | --- | --- |
| [External business decision, process, or party] | [Owner/source] | [IDs or milestone] | [Known or unresolved] |

## Risks

| Risk | Business impact | Mitigation or question | Owner/status |
| --- | --- | --- | --- |
| [Risk evidenced by sources or explicitly proposed] | [Impact] | [Action or decision] | [Owner/status] |

## Deferred Requirements

| Candidate | Source and deferral decision | Revisit trigger/owner | Status |
| --- | --- | --- | --- |
| [Deferred idea; not an active requirement] | [Source, decision owner/date] | [Trigger/owner] | Deferred |

[Rejected ideas remain in discovery unless the business explicitly reopens them.]

## Traceability Summary

| Business outcome | Success criterion | Business capability | Business rule | Functional requirement | Business-facing NFR | Source/status |
| --- | --- | --- | --- | --- | --- | --- |
| [Outcome] | SC-### | BC-### | BR-### or none | FR-### | NFR-### or none | [Approved source or proposed] |

[Check that every active BC, BR, FR, NFR, and SC is linked or explicitly explained as not
applicable. Keep IDs stable when revising the BRD.]

## Identifier Migration

[When revising a legacy identifier scheme, record each old ID, new ID, preserved meaning, and
rationale. A high-level legacy `UC-003` may become `BC-003`; action-level scenarios belong in the
TRD as `UC-003-01`, `UC-003-02`, and so on. Do not relabel an already detailed legacy scenario as a
capability. State "Not applicable" when no migration occurred.]

## Approval

- BRD status: Draft or In Review until the named approver explicitly approves this exact version.
- Outstanding decisions and approval blockers: [List unresolved scope, business policy, measures,
  or acceptance questions; otherwise state none.]
- Approval decision: None recorded until explicit approval. If approved, record approver, date,
  version, and scope here.
- Next step: Resolve blockers and request BRD approval. TRD drafting requires an approved BRD;
  development also requires later approved artifacts and review.
