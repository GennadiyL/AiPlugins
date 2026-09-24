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

| ID | Rule or unresolved rule | Source/status | Related use cases and requirements |
| --- | --- | --- | --- |
| BR-001 | [Testable business policy, or clearly marked unresolved decision] | [Approved decision or unresolved question] | [UC-###; FR-###] |

[Do not assign a rule value or threshold that the business has not decided.]

## Use Cases

### UC-001 — [Business goal]

- Priority and source: [Priority, if decided; approved source.]
- Role(s): [ROLE-### and responsibility.]
- Trigger: [Business event that starts the use case.]
- Preconditions: [Conditions known to be required; label any unresolved condition.]
- Main flow: [Numbered business steps from initiation to outcome.]
- Alternate and error flows: [Numbered deviations, rejection, and business failure outcomes; mark an
  unresolved policy branch rather than inventing it.]
- Outcome: [Observable business result and relevant record or notification, if approved.]
- Linked requirements: [BR-###, FR-###, NFR-###, SC-### as applicable.]
- Acceptance scenarios:
  - Given [business precondition], when [role performs business action], then [observable outcome].
  - Given [alternate or error condition], when [action occurs], then [observable business outcome].

[Repeat the complete structure for each use case.]

## Functional Requirements

| ID | Business capability and verifiable outcome | Priority/status | Source | Linked use cases and rules |
| --- | --- | --- | --- | --- |
| FR-001 | [The business must be able to...] | [Priority; approved or proposed] | [Approved source] | [UC-###; BR-###] |

## Business-Facing Non-Functional Requirements

| ID | Measurable business expectation | Measure/target/status | Source | Linked use cases |
| --- | --- | --- | --- | --- |
| NFR-001 | [Accessibility, timeliness, retention, or other business expectation] | [Unit, target, or unresolved decision] | [Approved source or proposed] | [UC-###] |

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

| Business outcome | Success criterion | Use case | Business rule | Functional requirement | Business-facing NFR | Source/status |
| --- | --- | --- | --- | --- | --- | --- |
| [Outcome] | SC-### | UC-### | BR-### or none | FR-### | NFR-### or none | [Approved source or proposed] |

[Check that every active UC, BR, FR, NFR, and SC is linked or explicitly explained as not
applicable. Keep IDs stable when revising the BRD.]

## Approval

- BRD status: Draft or In Review until the named approver explicitly approves this exact version.
- Outstanding decisions and approval blockers: [List unresolved scope, business policy, measures,
  or acceptance questions; otherwise state none.]
- Approval decision: None recorded until explicit approval. If approved, record approver, date,
  version, and scope here.
- Next step: Resolve blockers and request BRD approval. TRD drafting requires an approved BRD;
  development also requires later approved artifacts and review.
