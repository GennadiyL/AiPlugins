# Test project structure

Use the `Tests` solution-folder hierarchy below. As defined by `gl-dev-csharp-architecture`, these are solution folders; TemplateSolution keeps the physical project folders flat under the physical solution root.

```text
Tests/
|-- IntegrationTests/
|   `-- IntegrationTests
|-- ServiceTests/
|   |-- ServiceTests.Business
|   |-- ServiceTests.Domain1
|   `-- ServiceTests.Domain2
|-- UnitTests/
|   |-- UnitTests.Business
|   |-- UnitTests.Domain1
|   |-- UnitTests.Domain2
|   |-- UnitTests.{Tech1}
|   `-- UnitTests.{Tech2}
`-- Tests.Common
```

Create only the projects required by the solution. Technology projects may use concrete names such as `UnitTests.EntityFramework.MsSql`, `UnitTests.EntityFramework.SqLite`, or `UnitTests.AzureFunctions`.

## Service-test placement and naming

Give every tested service operation its own file. Place it under a project-internal folder named for the service and name it `{ServiceName}{FunctionName}ServiceTests.cs`.

```text
ServiceTests.Business/
`-- Services/
    `-- AuditEvents/
        `-- AuditEventsGetAuditEventsServiceTests.cs
```

## Service-test initialization

Use this order:

1. Create the repository and external-system mocks required by the fixture.
2. Create the service collection and load the normal Shared, business, messaging, adapter, and other applicable DI configurations.
3. Register shared mocks and override the specific DAL or external-system registrations required by the fixture. The override registrations must be the registrations selected when resolving a single service.
4. Build the service provider with scope validation enabled.
5. Create an `IServiceScope`.
6. Resolve the tested `IService` from the scope.
7. Store the provider, scope, service, and frequently configured mocks as fixture fields.
8. Dispose the scope and provider during teardown.

## Accessing internal implementations

When direct construction is appropriate, keep the implementation internal and grant access only to the exact test assembly. Put the assembly attribute in the project being tested:

```csharp
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests.Business")]
```

Add one attribute for each test assembly that genuinely requires internal access.

## Scenario-specific manual mocks

Reusable mocks in `Tests.Common` should expose virtual members when a test needs to specialize one behavior. Derive a focused test mock and override only that behavior:

```csharp
internal sealed class TestMockFileService : MockFileService
{
	public TestMockFileService(IDateTimeService dateTimeService)
		: base(dateTimeService)
	{
	}

	public override string ReadAllText(string path) =>
		path == @"C:\" ? "MyText" : "YourText";
}
```
