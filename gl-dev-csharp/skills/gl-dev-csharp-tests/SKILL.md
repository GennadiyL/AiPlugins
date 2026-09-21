---
name: gl-dev-csharp-tests
description: Use when creating, organizing, implementing, or reviewing GL NUnit integration tests, service tests, unit tests, test categories, dependency-injection test setup, mocks, or InternalsVisibleTo access.
---

# GL Dev CSharp Tests

Keep each test at the lowest level that proves the required behavior. Apply `gl-dev-csharp-common` to C# test source and `gl-dev-csharp-architecture` when adding or moving test projects.

## Categories

Every test fixture must have exactly one category:

- `[TestFixture(Category = "Local")]` uses only resources on the local machine. Keep Local tests fast enough to run after minor business-logic changes.
- `[TestFixture(Category = "Remote")]` may use local resources and remote databases, service buses, or third-party systems. Run Remote tests in CI/CD.

Tests inherit the fixture category. Do not mix Local and Remote tests in one fixture; split the fixture when resource requirements differ.

## Test types

| Type | Category | Responsibility |
|---|---|---|
| IntegrationTests | Remote | Exercise the complete infrastructure without mocks. Use production-like DI configuration. Keep this suite small: normally 2–3 tests per infrastructure unit plus a few tests covering combinations of external resources. Test infrastructure rather than business-rule permutations. |
| ServiceTests | Local | Exercise the complete flow of an `IService` operation while mocking the DAL and external systems. Enter through the service interface, not Web API, Azure Functions, or another infrastructure wrapper. Target roughly 60–70% of the test suite. |
| UnitTests, business | Local | Exercise an isolated piece of business-layer behavior. Initialize through DI or instantiate the class directly. |
| UnitTests, technology | Local or Remote | Exercise one technology-specific behavior. Use Remote when the test calls a remote resource, such as MS SQL; use Local when it stays local, such as SqLite. |

Target roughly 30–40% UnitTests across both unit-test types.

## Test setup

- For ServiceTests, create mocks, load the normal DI configurations, override selected registrations with mocks, build the provider, create a scope, and resolve the tested `IService`. Keep the provider, scope, service, and frequently configured mocks as fixture fields.
- Use NSubstitute or manually written mocks for external systems. Keep reusable manual mocks in `Tests.Common`.
- Prefer NSubstitute mocks of `IRepository`, `ICommand`, and `IQuery` for the DAL. Use an in-memory SqLite database only when its extra setup is justified, such as a large read-only reporting scenario.
- Reuse shared-service mocks through `SharedMockFactory` or register them through `SharedMockDiConfiguration`. Apply the same factory/configuration pattern to other frequently reused external-system mocks.
- When a test must instantiate an internal class directly, add `InternalsVisibleTo` for that exact test assembly to the project being tested instead of making the implementation public.

Read [references/test-project-structure.md](references/test-project-structure.md) for project placement, service-test naming, the detailed setup sequence, and focused examples.
