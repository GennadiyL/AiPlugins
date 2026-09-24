# TRD Quality and Handoff Checklist: [Feature Name]

## Review Metadata

- Feature folder: `requirements/NNN-feature-name/`
- Checklist path: `requirements/NNN-feature-name/checklists/trd-quality.md`
- Reviewed artifact: [path]
- Reviewed version and status: [version; Draft | In Review | Approved | Superseded]
- Exact BRD reference: [path, version, status, approver, approval date]
- Review date: [YYYY-MM-DD]
- Reviewer: [name or agent]
- Scope: [full TRD or named sections]
- Approval provenance checked: [approver, decision date, version, scope, and evidence location]

This checklist records review evidence. It does not approve, revise, supersede, or repair the TRD.

## Summary

- Verdict: [Pass | Pass with minor findings | Fail]
- Findings: [total; Blocker count; Important count; Minor count]
- Review coverage: [evaluated mandatory checks / total mandatory checks]
- Quality pass rate: [passed applicable checks / applicable checks]
- Traceability coverage: [covered plus valid non-system rows / all applicable BRD stable IDs]
- Development handoff: [Ready | Not ready]
- Handoff blockers: [finding IDs or none]

Review coverage measures whether each mandatory category was evaluated, even when it failed. Quality
pass rate measures conformity. Traceability coverage uses the separate traceability checklist and
retains Partial, Missing, Conflict, and unresolved IDs in its denominator.
An operation ID alone does not make a row Covered: a mapping is Partial when a mandatory contract
check needed by that BRD ID fails. A dependent aggregate requirement is Partial while any required
child or operation is Partial, Missing, or Conflict. Give every non-covered row a trace finding,
cross-reference duplicate root defects, and count each root defect once in the package total.
Each mandatory row evaluates the reviewed `trd.md` and its authoritative BRD references and cites
their exact section, row, or field. Do not cite this generated checklist's Summary, findings,
traceability artifact, or handoff gate as evidence for a source artifact check. The Development
Handoff Gate below is a separate derived package result.

## Mandatory Quality Checks

| Check ID | Category | Expected condition | Status | Evidence location | Finding IDs |
| --- | --- | --- | --- | --- | --- |
| TRD-C-001 | Exact BRD reference | The TRD names the exact validly Approved BRD version and approval provenance. | [Pass/Fail/Not applicable] | [section/table/line] | [IDs/none] |
| TRD-C-002 | Role and use-case mapping | Every BRD role/use case retains its meaning and maps to operations or justified non-system work. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-003 | Persistent schemas | Each model defines purpose, identifier, properties, relationships, constraints, lifecycle, concurrency, and auditing decisions/status. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-004 | DTO separation | DTOs are distinct from persistent models and persistent models never cross operation boundaries. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-005 | Canonical types | Every active schema property uses an allowed canonical type with source/decision status. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-006 | Nullability | Every active schema property states Required or Nullable separately from type. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-007 | Validation | Active properties and operations have source-backed validation or an explicit unresolved decision. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-008 | Operations | Each operation resolves BRD links, input/output, transaction, idempotency, and optional transport status. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-009 | Authorization | Every protected operation identifies authorized BRD role IDs and an authorization source. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-010 | Errors | Validation/domain errors have triggers, observable results, and source/decision status. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-011 | Side effects | Each operation states source-backed side effects or explicit none/unresolved status. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-012 | Transactions and idempotency | Each operation states both decisions/status without unsupported defaults. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-013 | Cross-cutting requirements | Security, data/integration, performance, reliability, and observability requirements are measurable or explicitly unresolved. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-014 | Unresolved questions | Material assumptions/questions have owners, affected IDs, and approval/handoff impact. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-015 | Full traceability | The reviewed TRD maps every applicable BRD stable ID and all source references resolve. | [Pass/Fail/Not applicable] | [`trd.md` traceability section and referenced `brd.md` sections] | [IDs/none] |
| TRD-C-016 | Architecture leakage | The TRD contains no C#/EF/project/file/class/interface or other implementation-owned decision. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |
| TRD-C-017 | Source readiness claim | The readiness statement inside the reviewed TRD is present and valid against that source artifact's recorded readiness conditions. | [Pass/Fail/Not applicable] | [`trd.md` Development Handoff Readiness] | [IDs/none] |
| TRD-C-018 | Approval provenance | Approved status, when present, is supported by an exact-version decision and scope. | [Pass/Fail/Not applicable] | [location] | [IDs/none] |

## Findings

| Finding ID | Severity | Evidence location | Affected IDs | Expected condition | Observed condition | Required disposition |
| --- | --- | --- | --- | --- | --- | --- |
| TRD-F-001 | [Blocker/Important/Minor] | [artifact and section/table/field] | [BRD/TRD IDs or document control] | [required condition] | [evidence-based defect] | [controlled correction or decision needed] |

Use stable local finding IDs when updating this checklist. Remove the example row when there are no
findings and state `No findings`.

## Development Handoff Gate

- Both authoritative artifacts are validly Approved: [Yes/No; evidence]
- All mandatory checks pass: [Yes/No; failed check IDs]
- Traceability is complete: [Yes/No; exact numerator/denominator]
- Blockers: [count and IDs]
- Important unresolved findings: [count and IDs]
- Handoff decision: [Ready | Not ready]
- Required remediation and re-review: [finding IDs, owners, and scope]

`Ready` requires Yes for the first three gates, zero blockers, and zero Important unresolved
findings. A percentage or Approved label cannot override a failed gate.
