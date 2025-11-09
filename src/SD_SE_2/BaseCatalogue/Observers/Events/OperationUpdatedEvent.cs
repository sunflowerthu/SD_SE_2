using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class OperationUpdatedEvent : DomainEvent
{
    public Operation OldOperation { get; }
    public Operation NewOperation { get; }

    public OperationUpdatedEvent(Operation oldOperation, Operation newOperation)
    {
        OldOperation = oldOperation;
        NewOperation = newOperation;
    }
}
