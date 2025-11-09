using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class OperationAddedEvent : DomainEvent
{
    public Operation Operation { get; }

    public OperationAddedEvent(Operation operation)
    {
        Operation = operation;
    }
}