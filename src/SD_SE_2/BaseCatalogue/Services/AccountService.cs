using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Observers.Events;
using SD_SE_2.BaseCatalogue.Observers.Publisher;
using SD_SE_2.BaseCatalogue.Repositories.Interfaces;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Services;

public class AccountService(
    IAccountRepository accountRepository, 
    IEventPublisher eventPublisher) : IAccountService
{
    public void AddAccount(BankAccount account)
    {
        accountRepository.Add(account);
        eventPublisher.Publish(new AccountAddedEvent(account));
    }

    public void UpdateAccount(BankAccount account)
    {
        var oldAccount = accountRepository.GetById(account.Id);
        if (oldAccount != null)
        {
            accountRepository.Update(account);
            eventPublisher.Publish(new AccountUpdatedEvent(oldAccount, account));
        }
    }

    public void DeleteAccount(BankAccount account)
    {
        var accountExists = accountRepository.GetById(account.Id);
        if (accountExists != null)
        { 
            accountRepository.Delete(account.Id);
            
            eventPublisher.Publish(new AccountDeletedEvent(account));
        }
        else
        {
            throw new NullReferenceException("Account not found");
        }
    }
    
    public BankAccount GetAccountById(Guid accountId)
    {
        try
        {
            var account = accountRepository.GetById(accountId);
            return account;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public IEnumerable<BankAccount> GetAllAccounts()
    {
        return accountRepository.GetAll();
    }

}