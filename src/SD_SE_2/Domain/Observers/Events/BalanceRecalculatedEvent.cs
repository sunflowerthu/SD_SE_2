namespace SD_SE_2.Domain.Observers.Events;

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