using SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Account;
using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.Factories.Interfaces;
using SD_SE_2.BaseCatalogue.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Facades;

public class AccountFacade(
    IAccountService accountService,
    IAccountFactory accountFactory,
    ICommandManager commandManager
    ) : IAccountFacade
{
    public void CreateAccount(string name, decimal initialBalance = 0)
    {
        var account = accountFactory.CreateAccount(name, initialBalance);
        var addAccountCommand = new AddAccountCommand(account, accountService);
        commandManager.ExecuteCommand(addAccountCommand);
    }

    public void EditAccount(Guid accountId, string newName = null, decimal? newBalance = null)
    {
        var oldAccount = accountService.GetAccountById(accountId);
        if (oldAccount == null)
        {
            throw new ArgumentException($"Account with ID {accountId} not found");
        }

        var newAccount = new BankAccount
        {
            Id = oldAccount.Id,
            Name = newName ?? oldAccount.Name,
            Balance = newBalance ?? oldAccount.Balance,
            IsActive = oldAccount.IsActive,
        };

        var editCommand = new EditAccountCommand(oldAccount, newAccount, accountService);
        commandManager.ExecuteCommand(editCommand);
    }

    public void DeleteAccount(Guid accountId)
    {
        var account = accountService.GetAccountById(accountId);
        if (account == null)
        {
            throw new ArgumentException($"Account with ID {accountId} not found");
        }

        var deleteCommand = new DeleteAccountCommand(account, accountService);
        commandManager.ExecuteCommand(deleteCommand);
    }
    public IEnumerable<BankAccount> GetAllAccounts()
    {
        return accountService.GetAllAccounts();
    }
}