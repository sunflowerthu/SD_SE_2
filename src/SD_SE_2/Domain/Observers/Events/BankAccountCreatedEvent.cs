using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Events;


public class BankAccountCreatedEvent : DomainEvent
{
    public BankAccount Account { get; }

    public BankAccountCreatedEvent(BankAccount account)
    {
        Account = account;
    }
}