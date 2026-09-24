# BRD Quality Checklist: [Feature Name]

## Review Metadata

- Feature folder: `requirements/NNN-feature-name/`
- Checklist path: `requirements/NNN-feature-name/checklists/brd-quality.md`
- Reviewed artifact: [path]
- Reviewed version and status: [version; Draft | In Review | Approved | Superseded]
- Review date: [YYYY-MM-DD]
- Reviewer: [name or agent]
- Scope: [full BRD or named sections]
- Approval provenance checked: [approver, decision date, version, scope, and evidence location]

This checklist records review evidence. It does not approve, revise, supersede, or repair the BRD.

## Summary

- Verdict: [Pass | Pass with minor findings | Fail]
- Findings: [total; Blocker count; Important count; Minor count]
- Review coverage: [evaluated mandatory checks / total mandatory checks]
- Quality pass rate: [passed applicable checks / applicable checks]
- Approval blockers: [finding IDs or none]

Review coverage measures whether each mandatory category was evaluated, even when it failed. Quality
pass rate measures conformity. State and justify `Not applicable`; do not use it to hide missing
content.
Each mandatory row evaluates the reviewed `brd.md` and cites its exact section, row, or field. Do
not cite this generated checklist's Summary, findings, or conclusions as evidence for a source
artifact check.

## Mandatory Quality Checks

| Check ID | Category | Expected condition | Status | Evidence location | Finding IDs |
| --- | --- | --- | --- | --- | --- |
| BRD-C-001 | Authority and status | Path, version, status, authority, and source provenance are explicit and consistent. | [Pass/Fail/Not applicable] | [section/table/line] | [IDs/none] |
| BRD-C-002 | Objectives | The business problem and objectives are clear, source-backed, and observable. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-003 | Stakeholders | Decision owners, approver, and affected stakeholders are identified. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-004 | Roles | Each active role has one stable ID, consistent meaning, and business responsibility. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-005 | Scope | In-scope, out-of-scope, deferred, and rejected material are distinguishable. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-006 | Business rules | Active rules are testable, source-backed, and free of unresolved material decisions. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-007 | Use-case flows | Each use case has role, trigger, preconditions, main flow, alternate/error flows, outcome, links, and acceptance scenarios. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-008 | Functional requirements | Functional requirements are verifiable, scoped, source-backed, and linked to use cases/rules. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-009 | Business-facing NFRs | Applicable expectations are measurable and linked, or their absence is explicit. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-010 | Measurable outcomes | Success criteria have calculation, baseline/source, target/timeframe, and evidence owner. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-011 | Assumptions and dependencies | Facts, assumptions, questions, and dependencies are separated with owners and impacts. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-012 | Risks | Material risks have impact, owner/status, and mitigation or decision need. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-013 | Stable IDs and links | Active ROLE/UC/BR/FR/NFR/SC IDs are unique, meaningful, and internally traceable. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-014 | Contradictions | No active statements or stable IDs have conflicting meaning. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-015 | Unresolved approval blockers | Material questions and proposed behavior are explicit and prevent false approval. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| BRD-C-016 | Approval provenance | Approved status, when present, is supported by an exact-version decision and scope. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |

## Findings

| Finding ID | Severity | Evidence location | Affected IDs | Expected condition | Observed condition | Required disposition |
| --- | --- | --- | --- | --- | --- | --- |
| BRD-F-001 | [Blocker/Important/Minor] | [artifact and section/table/field] | [BRD IDs or document control] | [required condition] | [evidence-based defect] | [controlled correction or decision needed] |

Use stable local finding IDs when updating this checklist. Remove the example row when there are no
findings and state `No findings`.

## Approval and Next Action

- Approval validity: [Valid for the reviewed version | Invalid/unsupported | Not applicable]
- Required remediation: [finding IDs and owner, or none]
- Re-review scope: [full or named checks/findings]
- Package impact: [handoff effect; BRD checklist alone cannot declare development Ready]
