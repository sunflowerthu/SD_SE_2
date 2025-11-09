namespace SD_SE_2.BaseCatalogue.Observers.Events;

public abstract class DomainEvent
{
    public DateTime OccurredAt { get; } = DateTime.Now;
    public Guid EventId { get; } = Guid.NewGuid();
}