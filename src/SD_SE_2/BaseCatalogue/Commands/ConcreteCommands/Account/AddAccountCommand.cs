using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Account;

public class AddAccountCommand : ICommand
{
    private readonly BankAccount _account;
    private readonly IAccountService _accountService;
    private bool _executed = false;

    public string Description => $"Add account: {_account.Name}";

    public AddAccountCommand(BankAccount account, IAccountService accountService)
    {
        _account = account;
        _accountService = accountService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _accountService.AddAccount(_account);
            _executed = true;
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _accountService.DeleteAccount(_account);
            _executed = false;
        }
    }
}