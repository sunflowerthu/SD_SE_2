using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class AccountAddedEvent : DomainEvent
{
    public BankAccount Account { get; }

    public AccountAddedEvent(BankAccount account)
    {
        Account = account;
    }
}