using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;

namespace SD_SE_2.Domain.Observers.Handlers;

public class NotificationHandler
{
    public NotificationHandler(IEventPublisher eventPublisher)
    {
        eventPublisher.Subscribe<OperationAddedEvent>(OnOperationAdded);
        eventPublisher.Subscribe<CategoryCreatedEvent>(OnCategoryCreated);
        eventPublisher.Subscribe<BankAccountCreatedEvent>(OnAccountCreated);
    }

    private void OnOperationAdded(OperationAddedEvent myEvent)
    {
        if (myEvent.Operation.Amount > 50000)
        {
            Console.WriteLine($"[NOTIFICATION] Important operation: {myEvent.Operation.Description}");
        }
    }

    private void OnCategoryCreated(CategoryCreatedEvent myEvent)
    {
        Console.WriteLine($"[NOTIFICATION] New category created: {myEvent.Category.Name}");
    }

    private void OnAccountCreated(BankAccountCreatedEvent myEvent)
    {
        Console.WriteLine($"[NOTIFICATION] New account created: {myEvent.Account.Name}");
    }
}