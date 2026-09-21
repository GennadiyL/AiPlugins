---
name: gl-dev-csharp-webapi
description: Use when implementing or reviewing GL ASP.NET Core Web API hosts, minimal API routes, endpoint handlers, HTTP request binding, or centralized HTTP exception handling.
---

# GL Dev CSharp WebApi

Keep the Web API as a thin infrastructure boundary over business-service interfaces. Apply `gl-dev-csharp-common` to C# source and follow `gl-dev-csharp-architecture` for solution placement and the canonical `TemplateSolution`.

## Endpoint responsibilities

- Prefer ASP.NET Core minimal APIs. Do not introduce controllers when a minimal API can implement the endpoint.
- Expose an endpoint for each operation in the relevant service interfaces.
- Keep endpoint handlers thin: bind the public input DTO, apply production authentication, convert the DTO only when the service signature requires different parameters, invoke the corresponding `IService` method, and return the service result with `Results.Ok`.
- Prefer passing the public DTO directly to the service when its contract already represents the use case.
- Keep business rules and repository access out of endpoint handlers. Put only HTTP- or host-dependent behavior in the Web API project.
- Configure production authentication through Web API middleware and endpoint metadata rather than business services.

## Routes and handlers

- Use `GET` for read operations. Bind a complex GET DTO from query parameters with `[AsParameters]`.
- Use `POST` for command/write operations and bind their DTOs from JSON request bodies.
- Map routes to static endpoint handlers through the Web API endpoint-composition class.
- Put service invocation logic in static `{Resource}Endpoint` classes under the `Endpoints` project-internal folder.
- Derive each handler name from its service method by removing the `Async` suffix and appending `Handler`: `GetTravelCentersAsync` becomes `GetTravelCentersHandler`.

```csharp
app.MapGet("/audit-events/get-audit-events", AuditEventsEndpoint.GetAuditEventsHandler);

public static async Task<IResult> GetAuditEventsHandler(
	[AsParameters] GetAuditEvents input,
	IAuditEventService service,
	CancellationToken cancellationToken = default)
{
	AuditEventInfos result = await service.GetAuditEventsAsync(input, cancellationToken);
	return Results.Ok(result);
}
```

## Host composition

- Keep `Program.cs` small. Register host infrastructure and middleware, build the application, activate middleware, and call route-composition methods there.
- Keep module registration in Web API DI configuration extensions and route declarations in the endpoint-composition class. Do not put service invocation logic in either location.

## Exception handling

- Implement and register one centralized ASP.NET Core exception handler, then activate it with `app.UseExceptionHandler()`.
- Log every handled exception.
- Convert expected validation or invalid-request exceptions to HTTP 400.
- Convert unavailable or not-found domain exceptions to HTTP 404.
- Convert unexpected exceptions to a safe HTTP 500 response that does not expose internal details.
- Return consistent problem details from the centralized handler; do not duplicate exception-to-status mapping in individual endpoints.
