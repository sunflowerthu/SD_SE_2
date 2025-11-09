namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class BalanceRecalculatedEvent : DomainEvent
{
    public Guid AccountId { get; }
    public decimal NewBalance { get; }

    public BalanceRecalculatedEvent(Guid accountId, decimal newBalance)
    {
        AccountId = accountId;
        NewBalance = newBalance;
    }
}