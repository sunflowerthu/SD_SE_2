using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class OperationDeletedEvent : DomainEvent
{
    public Operation Operation { get; }

    public OperationDeletedEvent(Operation operation)
    {
        Operation = operation;
    }
}
