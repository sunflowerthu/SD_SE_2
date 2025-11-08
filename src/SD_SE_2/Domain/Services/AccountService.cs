using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Observers.Events;
using SD_SE_2.Domain.Observers.Publisher;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Services;

public class AccountService
{
    private readonly IBankAccountRepository _accountRepository;
    private readonly IEventPublisher _eventPublisher;

    public AccountService(IBankAccountRepository accountRepository, IEventPublisher eventPublisher)
    {
        _accountRepository = accountRepository;
        _eventPublisher = eventPublisher;
    }

    public void CreateAccount(string name, decimal initialBalance = 0)
    {
        // сюда надо бы фабрику наверное или хз
        var account = new BankAccount(name,initialBalance);
        _accountRepository.Add(account);
        
        _eventPublisher.Publish(new BankAccountCreatedEvent(account));
    }

    public void UpdateAccount(BankAccount account)
    {
        _accountRepository.Update(account);
    }

    public void DeleteAccount(Guid accountId)
    {
        _accountRepository.Delete(accountId);
    }
}