using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;

public class OperationAddedEvent : DomainEvent
{
    public Operation Operation { get; }

    public OperationAddedEvent(Operation operation)
    {
        Operation = operation;
    }
}