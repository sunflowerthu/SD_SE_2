using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.Domain.Services.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.ConcreteCommands.Account;

public class EditAccountCommand(BankAccount oldAccount, BankAccount newAccount, IAccountService accountService)
    : ICommand
{
    private bool _executed = false;

    public string Description => $"Edit account: {oldAccount.Name} -> {newAccount.Name}";

    public void Execute()
    {
        if (!_executed)
        {
            accountService.UpdateAccount(newAccount);
            _executed = true;
            Console.WriteLine($"[COMMAND] Account edited: {oldAccount.Name} -> {newAccount.Name}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            accountService.UpdateAccount(oldAccount);
            _executed = false;
            Console.WriteLine($"[COMMAND] Account edit undone: {newAccount.Name} -> {oldAccount.Name}");
        }
    }
}