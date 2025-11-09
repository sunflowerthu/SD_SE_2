using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;

public class AccountAddedEvent : DomainEvent
{
    public BankAccount Account { get; }

    public AccountAddedEvent(BankAccount account)
    {
        Account = account;
    }
}