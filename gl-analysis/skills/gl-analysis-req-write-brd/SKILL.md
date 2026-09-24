---
name: gl-analysis-req-write-brd
description: Use when a feature's business requirements, use cases, or brd.md need drafting or revision from discovery decisions.
---

# GL Analysis: Write Business Requirements

Produce or revise `requirements/NNN-feature-name/brd.md` as the feature's business requirements
document. A draft is reviewable but has no approval authority.

Read [the artifact contract](../../references/artifact-contract.md) and
[the BRD template](../../assets/templates/brd-template.md) before writing. Read the feature's
`discovery.md`, the current user request, applicable repository approval policy, other cited source
decisions, and an existing BRD if present. Preserve stable IDs for unchanged meanings.

1. Confirm discovery is approved. For the discovery-to-business promotion decision, accept either a
   recorded discovery decision or an explicit current user instruction to create or revise a BRD
   from that approved discovery. If repository policy names a separate authorized promoter, require
   that promoter's decision. Record the qualifying source, date, and scope in BRD Document Control.
   If the applicable gate is absent, or the business problem, scope, decision owner, or core rule is
   too uncertain to draft safely, identify the blocker and ask the highest-impact question.
   Promotion authorizes drafting only; discovery approval does not approve the BRD. Do not treat
   rejected or deferred ideas as active requirements.
2. Fill every template section using approved discovery facts and decisions. Attribute source facts;
   separate assumptions, unresolved questions, and proposed wording from approved decisions. Ask
   rather than choose a material business limit, threshold, policy, or success target. A question
   that can remain in a safe draft stays labeled and blocks approval until resolved.
3. Use `ROLE-###`, `UC-###`, `BR-###`, `FR-###`, `NFR-###`, and `SC-###` from the contract. Give each
   use case a role, trigger, preconditions, main flow, alternate/error flows, outcome, linked
   requirements, and Given/When/Then scenarios. Make objectives and success measures observable;
   record unknown baselines or targets as approval questions. Trace active IDs to source and
   business outcomes; retain explicit scope, exclusions, dependencies, risks, and deferred items.
   Every active main-flow step, alternate/error flow, outcome, and acceptance scenario must be
   supported by an approved source. If the source does not define the behavior, mark that field
   unresolved or proposed instead of inventing an active rule; a generic approval/rejection does
   not itself establish that a decision is recorded, communicated, or assigned a status. Link the
   gap to an assumption or question and its affected IDs; mark it an approval blocker when material.
   Label proposed Given/When/Then scenarios separately until the business accepts them.
4. Keep the BRD at the business level. Describe required behavior and results without C#, ASP.NET,
   databases, endpoints, DTOs, service interfaces, architecture, projects, or source placement.
   Technical preferences in the request can be noted as later design input, never promoted to BRD
   requirements without a business decision.
5. Review completeness and contradictions. Leave status `Draft` or `In Review` and record every
   approval blocker. Stop for explicit approval of this BRD version; do not claim approval, start a
   TRD, or authorize development from a draft.

If the feature location is unavailable, present the BRD content in the reply and identify the
unresolved save location. When a later approved decision changes a requirement, update that item and
its trace links in place instead of adding a duplicate.
