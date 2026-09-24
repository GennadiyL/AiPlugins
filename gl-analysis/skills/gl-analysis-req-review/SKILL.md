---
name: gl-analysis-req-review
description: Use when BRD/TRD quality, consistency, traceability, checklists, or development handoff readiness need review.
---

# GL Analysis: Review Requirements

Review one feature package without changing its requirements. Produce evidence-based BRD, TRD, and
cross-artifact checklists; an Approved label never overrides a defect.

Before reviewing, read [the artifact contract](../../references/artifact-contract.md),
[the canonical types](../../references/canonical-types.md),
[the BRD checklist template](../../assets/templates/brd-checklist-template.md), and
[the TRD checklist template](../../assets/templates/trd-checklist-template.md). Read the exact
`brd.md`, `trd.md`, optional `discovery.md`, applicable repository policy, and existing checklists in
the feature folder. Discovery can explain provenance but cannot repair or override approved content.

## Preserve authority

Treat Approved BRD and TRD content as read-only. The review request authorizes only these outputs:

- `requirements/NNN-feature-name/checklists/brd-quality.md`
- `requirements/NNN-feature-name/checklists/trd-quality.md`
- `requirements/NNN-feature-name/checklists/traceability.md`

Record defects and required dispositions. Do not silently repair, reinterpret, approve, supersede,
or change the status/version of a BRD or TRD. A requested correction needs a separate explicit
controlled-revision request and a later re-review. Do not treat pressure to "quick approve" or
"fix silently" as that request.

## Evaluate and record evidence

1. Verify artifact paths, exact versions/statuses, approval provenance, authority, and review scope.
   Apply every mandatory row in both templates. State and justify a `Not applicable` result; it is
   an evaluated result, not permission to skip a category.
   Every mandatory-row status and evidence location evaluates the reviewed source artifact
   (`brd.md`, `trd.md`, and their authoritative cross-references), never a conclusion written into
   the generated checklist. A checklist cannot cite its own Summary, findings, traceability output,
   or handoff gate as proof that the reviewed source passed. Cite the precise source section, row,
   or field; record missing source evidence as a failure.
2. Resolve all internal and cross-artifact references. Compare the meaning, not only the spelling,
   of every reused stable ID. Review BRD objectives, stakeholders, roles, scope, rules, complete
   use-case flows, functional requirements, measurable outcomes, assumptions, risks, contradictions,
   unresolved blockers, stable IDs, and approval. Review the exact BRD reference, role/use-case
   mapping, persistent schemas, DTO separation, canonical types, nullability, validation,
   operations, authorization, errors, side effects, transaction/idempotency, cross-cutting
   requirements, unresolved questions, full traceability, architecture leakage, readiness, and
   approval in the TRD.
3. Give each finding a stable checklist-local ID such as `BRD-F-001`, `TRD-F-001`, or
   `TRACE-F-001`. Every finding row contains severity (`Blocker`, `Important`, or `Minor`), precise
   evidence location, affected requirement/contract IDs, expected condition, observed condition,
   and required disposition. Preserve an existing finding ID when the same defect persists.
4. Assign `Blocker` to a missing required mapping, undefined required contract, persistent model at
   an operation boundary, missing authorization or authorization source for a protected operation,
   conflicting stable-ID meaning, material unresolved question, unsupported approval/readiness
   claim, or other defect that makes implementation unsafe or indeterminate. Assign `Important` to
   a material quality defect that must be resolved before handoff but does not itself make a
   contract undefined. Assign `Minor` only when handoff safety and meaning are unaffected.

## Calculate traceability exactly

Create `traceability.md` with review metadata, verdict, finding/blocker counts, coverage, the matrix,
findings, and handoff impact. Its matrix columns are exactly:

```text
BRD ID | TRD ID(s) | Status | Notes
```

Enumerate every applicable active `ROLE-###`, `UC-###`, `BR-###`, `FR-###`, `NFR-###`, and
`SC-###` in the reviewed BRD. Each receives exactly one row with `Covered`, `Partial`, `Missing`,
`Non-system`, or `Conflict`. `Non-system` is valid only when the TRD explicitly justifies the
classification without contradicting the BRD.

`Covered` means the mapped technical contract passes every mandatory check needed to satisfy that
BRD ID. A nominal operation link is `Partial`, not `Covered`, when its operation fails a required
boundary, authorization, schema, validation, error, side-effect, transaction, idempotency, or other
mandatory contract check for that BRD ID. An aggregate requirement that depends on a Partial,
Missing, or Conflict child or operation is also `Partial`, even when another dependency passes.

The denominator is every applicable BRD ID enumerated above. Do not remove Partial, Missing,
Conflict, unresolved, or defective IDs from it. The numerator is `Covered` plus valid `Non-system`
rows. Report the exact numerator/denominator and percentage; never round it into a passing claim.
Create a finding for every Partial, Missing, or Conflict row and for an unsupported Non-system row.
When several rows expose the same underlying defect, give each non-covered row its required local
trace finding and cross-reference the canonical defect finding. Count that underlying defect once
in the package blocker/remediation total; dependent rows do not create new unique defects.

## Decide the gates

Evaluate the TRD readiness-claim check against the readiness statement inside the reviewed
`trd.md`. Then derive the package handoff gate separately from all completed checks, traceability,
and findings. The derived `Ready`/`Not ready` result is an output, not evidence for the source check.

- Checklist verdicts are `Pass`, `Pass with minor findings`, or `Fail`.
- `Fail` applies when any Blocker or Important unresolved finding exists, a mandatory check fails,
  or coverage is incomplete. `Pass with minor findings` requires only Minor findings. `Pass`
  requires no findings.
- Development handoff is `Ready` only when both authoritative artifacts are validly Approved, every
  mandatory check passes, traceability numerator equals denominator, and there are zero Blockers
  and zero Important unresolved findings across all three checklists. Otherwise it is `Not ready`.
- Report total and per-checklist finding counts without double-counting one defect in the package
  remediation summary. Name each failed gate and the controlled revision or decision needed.

Stop after writing the three checklist artifacts and an actionable remediation summary. Do not
invoke or imitate a development skill, create implementation tasks or tests, or generate C#,
projects, interfaces, classes, EF configuration, files, or application code.

If the feature location is unavailable, present the three complete checklist contents in the reply
and identify the unresolved save location. Do not replace them with an informal approval summary.
