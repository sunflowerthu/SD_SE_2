using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class AccountDeletedEvent : DomainEvent
{
    public BankAccount Account { get; }

    public AccountDeletedEvent(BankAccount account)
    {
        Account = account;
    }
}