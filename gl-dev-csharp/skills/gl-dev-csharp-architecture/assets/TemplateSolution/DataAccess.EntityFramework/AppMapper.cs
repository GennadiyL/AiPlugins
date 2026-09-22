using Business.Core.Entities;
using DataAccess.Core.Behaviors;
using DataAccess.Core.Entities;
using DataAccess.EntityFramework.Models;

using AuditEventEntity = Business.Models.Entities.AuditEvent;
#pragma warning disable CA1859

namespace DataAccess.EntityFramework;

/// <summary>
/// Defines the application persistence mapper.
/// Maps supported persistent business models to and from Entity Framework entities.
/// Repositories resolve the mapper through IMapper for single values and collections.
/// It isolates Business.Models from DataAccess.EntityFramework.Models.
/// Unsupported mappings fail explicitly instead of using reflection-based conventions.
/// </summary>
internal class AppMapper : IMapper
{
	public TDal Map<TDal, TBus>(TBus bus)
		where TDal : class, IDalEntity, new()
		where TBus : class, IBaseEntity, new()
	{
		ArgumentNullException.ThrowIfNull(bus);
		return MapBusinessToDal(bus) is TDal mapped
			? mapped
			: throw UnsupportedMapping(typeof(TBus), typeof(TDal));
	}

	public ICollection<TDal> Map<TDal, TBus>(ICollection<TBus> bus)
		where TDal : class, IDalEntity, new()
		where TBus : class, IBaseEntity, new()
	{
		ArgumentNullException.ThrowIfNull(bus);
		return [.. bus.Select(Map<TDal, TBus>)];
	}

	public TBus Map<TDal, TBus>(TDal dal)
		where TDal : class, IDalEntity, new()
		where TBus : class, IBaseEntity, new()
	{
		ArgumentNullException.ThrowIfNull(dal);
		return MapDalToBusiness(dal) is TBus mapped
			? mapped
			: throw UnsupportedMapping(typeof(TDal), typeof(TBus));
	}

	public ICollection<TBus> Map<TDal, TBus>(ICollection<TDal> dal)
		where TDal : class, IDalEntity, new()
		where TBus : class, IBaseEntity, new()
	{
		ArgumentNullException.ThrowIfNull(dal);
		return [.. dal.Select(Map<TDal, TBus>)];
	}

	private static IDalEntity MapBusinessToDal(IBaseEntity entity) => entity switch
	{
		AuditEventEntity value => Map(value),
		_ => throw UnsupportedMapping(entity.GetType(), typeof(IDalEntity))
	};

	private static IBaseEntity MapDalToBusiness(IDalEntity entity) => entity switch
	{
		AuditEvent value => Map(value),
		_ => throw UnsupportedMapping(entity.GetType(), typeof(IBaseEntity))
	};

	private static ArgumentException UnsupportedMapping(Type sourceType, Type destinationContract) =>
		new($"No mapping is configured from '{sourceType.FullName}' to '{destinationContract.Name}'.",
			nameof(sourceType));

	private static AuditEvent Map(AuditEventEntity value) => new()
	{
		Id = value.Id,
		OccurredAt = value.OccurredAt,
		EventType = value.EventType,
		AggregateType = value.AggregateType,
		AggregateId = value.AggregateId,
		CorrelationId = value.CorrelationId,
		ActorType = value.ActorType,
		ActorReference = value.ActorReference,
		EventDataJson = value.EventDataJson,
		Source = value.Source
	};

	private static AuditEventEntity Map(AuditEvent value) => new()
	{
		Id = value.Id,
		OccurredAt = value.OccurredAt,
		EventType = value.EventType,
		AggregateType = value.AggregateType,
		AggregateId = value.AggregateId,
		CorrelationId = value.CorrelationId,
		ActorType = value.ActorType,
		ActorReference = value.ActorReference,
		EventDataJson = value.EventDataJson,
		Source = value.Source
	};
}
