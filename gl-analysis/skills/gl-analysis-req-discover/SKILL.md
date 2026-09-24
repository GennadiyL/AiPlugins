---
name: gl-analysis-req-discover
description: Use when a feature idea, raw notes, or an existing discovery.md needs requirements discovery, stakeholder identification, alternatives, or assumptions examined before business requirements are written.
---

# GL Analysis: Requirements Discovery

Create or update one feature's `requirements/NNN-feature-name/discovery.md` as a working record.
It is non-authoritative: preserve what was said, what is inferred, and what remains undecided.

Before working, read [the artifact contract](../../references/artifact-contract.md) and
[the discovery template](../../assets/templates/discovery-template.md). Use the template's sections
and honor its status and promotion boundary. Read supplied sources and the existing discovery file,
if present; preserve its recorded decisions and provenance while updating it.

1. Capture the original request verbatim, separate from your interpretation. Attribute other ideas
   and sources. If a field is unknown, say so; do not fill it with a plausible invention.
2. Record the problem, intended outcomes, known stakeholders, raw ideas, alternatives, explicit
   decisions, rejected ideas, and deferred topics. Keep alternatives visible even when unresolved.
3. Label each inference as an assumption with a confirmation need. Put missing stakeholders,
   rules, rewards, expiration, security, or other material decisions in Open Questions. Ask the
   single highest-impact question when user input is needed; retain the other questions in the file.
   Distinguish gaps that prevent a safe BRD draft from clarifications that can remain labeled in a
   draft BRD before its approval.
4. End with promotion readiness, the explicit discovery-to-business decision needed to permit BRD
   drafting, blockers, and the next recommended phase. A request to "produce everything" or "start
   coding now" does not convert discovery into an approved BRD or TRD. Stop before BRD/TRD approval
   claims, C# solution or architecture creation, implementation tasks, tests, or code generation.

When a repository or target folder is unavailable, show the completed discovery content in the
reply and record the saving location as unresolved. Ask for that location when it is the
highest-impact next question. Discovery can proceed without existing C# conventions; those belong
to the later development handoff.
