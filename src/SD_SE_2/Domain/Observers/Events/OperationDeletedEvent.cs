using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;

public class OperationDeletedEvent : DomainEvent
{
    public Operation Operation { get; }

    public OperationDeletedEvent(Operation operation)
    {
        Operation = operation;
    }
}
