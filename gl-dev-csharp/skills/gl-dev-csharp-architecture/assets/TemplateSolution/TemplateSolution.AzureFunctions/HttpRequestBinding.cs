using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TemplateSolution.AzureFunctions;

/// <summary>
/// Defines the HTTP request binding helper.
/// Reads and validates request payloads for Azure Functions endpoints.
/// Function handlers call it to translate HTTP request bodies into contract DTOs.
/// It keeps transport parsing separate from business-service invocation.
/// It does not execute business validation or persistence.
/// </summary>
internal static class HttpRequestBinding
{
	public static async Task<(T? Value, IActionResult? Error)> ReadJsonAsync<T>(HttpRequest request, CancellationToken cancellationToken)
		where T : class
	{
		try
		{
			T? value = await request.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
			return value is null
				? (null, BadRequest("A JSON request body is required."))
				: (value, null);
		}
		catch (JsonException)
		{
			return (null, BadRequest("The JSON request body is invalid."));
		}
	}

	public static bool TryGetRequiredGuid(HttpRequest request, string name, out Guid value) =>
		Guid.TryParse(request.Query[name], out value);

	public static bool TryGetRequiredEnum<T>(HttpRequest request, string name, out T value)
		where T : struct, Enum =>
		Enum.TryParse(request.Query[name], true, out value);

	public static Guid? GetOptionalGuid(HttpRequest request, string name) =>
		Guid.TryParse(request.Query[name], out Guid value) ? value : null;

	public static T? GetOptionalEnum<T>(HttpRequest request, string name)
		where T : struct, Enum =>
		Enum.TryParse(request.Query[name], true, out T value) ? value : null;

	public static DateTime? GetOptionalDateTime(HttpRequest request, string name) =>
		DateTime.TryParse(request.Query[name], CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out DateTime value)
			? value
			: null;

	public static int GetOptionalInt32(HttpRequest request, string name) =>
		int.TryParse(request.Query[name], NumberStyles.Integer, CultureInfo.InvariantCulture, out int value) ? value : 0;

	public static IActionResult BadRequest(string detail) => new BadRequestObjectResult(new ProblemDetails
	{
		Status = StatusCodes.Status400BadRequest,
		Title = detail
	});
}
