using SD_SE_2.BaseCatalogue.Observers.Events;
using SD_SE_2.BaseCatalogue.Observers.Publisher;

namespace SD_SE_2.BaseCatalogue.Observers.Handlers;

public class OperationAuditHandler
{
    private readonly List<string> _auditLog = new();

    public OperationAuditHandler(IEventPublisher eventPublisher)
    {
        eventPublisher.Subscribe<OperationAddedEvent>(OnOperationAdded);
        eventPublisher.Subscribe<OperationUpdatedEvent>(OnOperationUpdated);
        eventPublisher.Subscribe<OperationDeletedEvent>(OnOperationDeleted);
    }

    private void OnOperationAdded(OperationAddedEvent myEvent)
    {
        var message = $"[AUDIT] Operation added: {myEvent.Operation.Description} - {myEvent.Operation.Amount:C}";
        _auditLog.Add(message);
        Console.WriteLine(message);
    }

    private void OnOperationUpdated(OperationUpdatedEvent myEvent)
    {
        var message = $"[AUDIT] Operation updated: {myEvent.OldOperation.Description} -> {myEvent.NewOperation.Description}";
        _auditLog.Add(message);
        Console.WriteLine(message);
    }

    private void OnOperationDeleted(OperationDeletedEvent myEvent)
    {
        var message = $"[AUDIT] Operation deleted: {myEvent.Operation.Description}";
        _auditLog.Add(message);
        Console.WriteLine(message);
    }

    public void PrintAuditLog()
    {
        Console.WriteLine("\n=== AUDIT LOG ===");
        foreach (var entry in _auditLog)
        {
            Console.WriteLine(entry);
        }
    }
}