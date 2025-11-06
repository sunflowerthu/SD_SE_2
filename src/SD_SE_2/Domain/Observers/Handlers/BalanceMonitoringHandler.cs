using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;

public class BalanceMonitoringHandler
{
    public BalanceMonitoringHandler(IEventPublisher eventPublisher)
    {
        eventPublisher.Subscribe<BalanceRecalculatedEvent>(OnBalanceRecalculated);
    }

    private void OnBalanceRecalculated(BalanceRecalculatedEvent myEvent)
    {
        if (myEvent.NewBalance < 0)
        {
            Console.WriteLine($"[ALERT] Negative balance on account {myEvent.AccountId}: {myEvent.NewBalance:C}");
        }
        
        if (myEvent.NewBalance > 1000000)
        {
            Console.WriteLine($"[INFO] Large balance detected: {myEvent.NewBalance:C}");
        }
    }
}