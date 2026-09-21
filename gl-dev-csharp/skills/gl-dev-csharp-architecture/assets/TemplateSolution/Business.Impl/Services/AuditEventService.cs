using Business.Contracts.Services;
using Business.Contracts.Services.AuditEvent;
using Business.Models.Entities;
using Business.Models.Exceptions;
using DataAccess.Contracts;
using Shared.Contracts;

namespace Business.Impl.Services;

/// <summary>
/// Defines the audit-event business service.
/// Validates audit-event searches, queries the unit of work, and maps models to service DTOs.
/// The dependency injection container creates one scoped instance for IAuditEventService consumers.
/// It coordinates IAppUnitOfWork persistence and ISharedContext cross-cutting services.
/// It does not expose data-access entities or transport-specific behavior.
/// </summary>
internal sealed class AuditEventService : IAuditEventService
{
	private readonly IAppUnitOfWork _unitOfWork;
	private readonly ISharedContext _sharedContext;

	public AuditEventService(ISharedContext sharedContext, IAppUnitOfWork unitOfWork)
	{
		_sharedContext = sharedContext ?? throw new ArgumentNullException(nameof(sharedContext));
		_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
	}

	public Task<AuditEventInfos> GetAuditEventsAsync(GetAuditEvents input,
		CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();
		ValidateGetAuditEvents(input);
		return GetAuditEventsCoreAsync(input, cancellationToken);
	}

	private async Task<AuditEventInfos> GetAuditEventsCoreAsync(
		GetAuditEvents input,
		CancellationToken cancellationToken)
	{
		_sharedContext.LogService.Info($"GetAuditEventsCoreAsync {input}");

		long pageOffset = ((long)input.PageNumber - 1) * input.PageSize;
		long totalCount = await _unitOfWork.AuditEventRepo.CountAuditEventsAsync(
			input.From,
			input.To,
			cancellationToken);

		if (pageOffset > int.MaxValue)
		{
			return new AuditEventInfos
			{
				PageNumber = input.PageNumber,
				PageSize = input.PageSize
			};
		}

		ICollection<AuditEvent> auditEvents = await _unitOfWork.AuditEventRepo.GetAuditEventsAsync(
			input.From,
			input.To,
			(int)pageOffset,
			input.PageSize,
			cancellationToken);
		cancellationToken.ThrowIfCancellationRequested();

		AuditEventInfos result = new()
		{
			PageNumber = input.PageNumber,
			PageSize = input.PageSize,
			Total = totalCount
		};

		foreach (AuditEventInfo auditEventInfo in auditEvents.Select(CreateAuditEventInfo))
		{
			result.AuditEventInfosList.Add(auditEventInfo);
		}

		return result;
	}

	private static AuditEventInfo CreateAuditEventInfo(AuditEvent auditEvent) => new()
	{
		AuditEventId = auditEvent.Id,
		OccurredAt = auditEvent.OccurredAt
	};

	private static void ValidateGetAuditEvents(GetAuditEvents? input)
	{
		if (input == null)
		{
			throw new InvalidAuditEventSearchException("An audit-event search request is required.");
		}

		if (input.PageNumber < 1 || input.PageSize < 1)
		{
			throw new InvalidAuditEventSearchException("PageNumber and PageSize must be greater than zero.");
		}

		if (input.From.HasValue && input.To.HasValue && input.From.Value > input.To.Value)
		{
			throw new InvalidAuditEventSearchException("From cannot be later than To.");
		}
	}
}
