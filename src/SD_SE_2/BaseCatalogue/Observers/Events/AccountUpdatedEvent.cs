using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Observers.Events;

public class AccountUpdatedEvent : DomainEvent
{
    public BankAccount OldAccount { get; }
    public BankAccount NewAccount { get; }

    public AccountUpdatedEvent(BankAccount oldAccount, BankAccount newAccount)
    {
        OldAccount = oldAccount;
        NewAccount = newAccount;
    }
}