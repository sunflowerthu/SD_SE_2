using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Account;

public class DeleteAccountCommand : ICommand
{
    private readonly BankAccount _account;
    private readonly IAccountService _accountService;
    private bool _executed = false;

    public string Description => $"Delete account: {_account.Name}";
    
    public DeleteAccountCommand(BankAccount account, IAccountService accountService)
    {
        _account = account;
        _accountService = accountService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _accountService.DeleteAccount(_account);
            _executed = true;
            Console.WriteLine($"[COMMAND] Account deleted: {_account.Name}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _accountService.AddAccount(_account);
            _executed = false;
            Console.WriteLine($"[COMMAND] Account deletion undone: {_account.Name}");
        }
    }
}