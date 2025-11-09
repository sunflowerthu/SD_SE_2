using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;

public class AccountDeletedEvent : DomainEvent
{
    public BankAccount Account { get; }

    public AccountDeletedEvent(BankAccount account)
    {
        Account = account;
    }
}