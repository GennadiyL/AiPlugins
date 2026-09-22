using Business.Contracts.Services;
using Business.Contracts.Services.AuditEvent;
using Business.Impl;
using Business.Models.Entities;
using Business.Models.Exceptions;
using DataAccess.Contracts;
using DataAccess.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using Shared.Impl;
using Tests.Common.DiConfigurations;

#pragma warning disable JSON002

namespace ServiceTests.Business.Services.AuditEvents;

[TestFixture(Category = "Local")]
public sealed class AuditEventsGetAuditEventsServiceTests
{
	private ServiceProvider _provider = null!;
	private IServiceScope _scope = null!;
	private IAuditEventService _service = null!;
	private IAuditEventRepository _repository = null!;

	[SetUp]
	public void SetUp()
	{
		_repository = Substitute.For<IAuditEventRepository>();
		IAppUnitOfWork unitOfWork = Substitute.For<IAppUnitOfWork>();
		unitOfWork.AuditEventRepo.Returns(_repository);

		IServiceCollection services = new ServiceCollection();
		services.AddSharedModule();
		services.AddBusinessModule();
		services.AddSharedMockModule();
		services.AddScoped<IAppUnitOfWork>(_ => unitOfWork);
		_provider = services.BuildServiceProvider(validateScopes: true);
		_scope = _provider.CreateScope();
		_service = _scope.ServiceProvider.GetRequiredService<IAuditEventService>();
	}

	[TearDown]
	public void TearDown()
	{
		_scope?.Dispose();
		_provider?.Dispose();
	}

	[Test]
	public async Task GetAuditEventsAsync_ValidSearch_ReturnsThreeMappedEventsAndPagingMetadata()
	{
		DateTime from = new(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc);
		DateTime to = new(2026, 9, 2, 0, 0, 0, DateTimeKind.Utc);
		Guid firstId = Guid.Parse("5b1f2e63-62ad-4cbd-8d34-e2d3eb1e9e71");
		Guid secondId = Guid.Parse("9f3a9a0c-cc2f-4faa-b2a5-2ce4ed5d3d44");
		Guid thirdId = Guid.Parse("a3e6bba0-74d5-4f46-a8fe-3bfdb542eff1");
		_repository.CountAuditEventsAsync(from, to, Arg.Any<CancellationToken>()).Returns(Task.FromResult(8L));
		_repository.GetAuditEventsAsync(from, to, 3, 3, Arg.Any<CancellationToken>()).Returns(
			Task.FromResult<ICollection<AuditEvent>>([
				CreateAuditEvent(firstId, from.AddHours(1)),
				CreateAuditEvent(secondId, from.AddHours(2)),
				CreateAuditEvent(thirdId, from.AddHours(3))
			]));

		AuditEventInfos result = await _service.GetAuditEventsAsync(new GetAuditEvents
		{
			From = from,
			To = to,
			PageNumber = 2,
			PageSize = 3
		});

		Assert.Multiple(() =>
		{
			Assert.That(result.Total, Is.EqualTo(8));
			Assert.That(result.PageNumber, Is.EqualTo(2));
			Assert.That(result.PageSize, Is.EqualTo(3));
			Assert.That(result.AuditEventInfosList, Has.Count.EqualTo(3));
			Assert.That(result.AuditEventInfosList.Select(x => x.AuditEventId), Is.EqualTo([firstId, secondId, thirdId]));
			Assert.That(result.AuditEventInfosList.Select(x => x.OccurredAt), Is.EqualTo([from.AddHours(1), from.AddHours(2), from.AddHours(3)]));
		});
	}

	[Test]
	public void GetAuditEventsAsync_NullInput_ThrowsInvalidSearchException()
	{
		Assert.ThrowsAsync<InvalidAuditEventSearchException>(async () => await _service.GetAuditEventsAsync(null!));
	}

	[Test]
	public void GetAuditEventsAsync_FromLaterThanTo_ThrowsInvalidSearchException()
	{
		GetAuditEvents input = new()
		{
			From = new DateTime(2026, 9, 2),
			To = new DateTime(2026, 9, 1),
			PageNumber = 1,
			PageSize = 25
		};

		Assert.ThrowsAsync<InvalidAuditEventSearchException>(async () => await _service.GetAuditEventsAsync(input));
	}

	[TestCase(0, 25)]
	[TestCase(-1, 25)]
	[TestCase(1, 0)]
	[TestCase(1, -1)]
	public void GetAuditEventsAsync_NonPositivePageNumberOrSize_ThrowsInvalidSearchException(int pageNumber, int pageSize)
	{
		GetAuditEvents input = new()
		{
			PageNumber = pageNumber,
			PageSize = pageSize
		};

		Assert.ThrowsAsync<InvalidAuditEventSearchException>(async () => await _service.GetAuditEventsAsync(input));
	}

	[Test]
	public async Task GetAuditEventsAsync_PageOffsetOutsideRepositoryRange_ReturnsEmptyPage()
	{
		_repository.CountAuditEventsAsync(null, null, Arg.Any<CancellationToken>()).Returns(Task.FromResult(15L));

		AuditEventInfos result = await _service.GetAuditEventsAsync(new GetAuditEvents
		{
			PageNumber = int.MaxValue,
			PageSize = 2
		});

		Assert.Multiple(() =>
		{
			Assert.That(result.AuditEventInfosList, Is.Empty);
			Assert.That(result.PageNumber, Is.EqualTo(int.MaxValue));
			Assert.That(result.PageSize, Is.EqualTo(2));
			Assert.That(result.Total, Is.Zero);
		});
	}

	private static AuditEvent CreateAuditEvent(Guid id, DateTime occurredAt) => new()
	{
		Id = id,
		OccurredAt = occurredAt,
		EventType = "EventRecorded",
		AggregateType = "Order",
		AggregateId = Guid.NewGuid(),
		CorrelationId = "correlation-1",
		ActorType = "System",
		EventDataJson = "{\"status\":\"created\"}",
		Source = "test"
	};
}
