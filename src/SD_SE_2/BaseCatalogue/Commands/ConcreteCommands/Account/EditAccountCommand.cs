using SD_SE_2.Domain.Commands;
using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Services.Interfaces;

public class EditAccountCommand : ICommand
{
    private readonly BankAccount _oldAccount;
    private readonly BankAccount _newAccount;
    private readonly IAccountService _accountService;
    private bool _executed = false;

    public string Description => $"Edit account: {_oldAccount.Name} -> {_newAccount.Name}";

    public EditAccountCommand(BankAccount oldAccount, BankAccount newAccount, IAccountService accountService)
    {
        _oldAccount = oldAccount;
        _newAccount = newAccount;
        _accountService = accountService;
    }

    public void Execute()
    {
        if (!_executed)
        {
            _accountService.UpdateAccount(_newAccount);
            _executed = true;
            Console.WriteLine($"[COMMAND] Account edited: {_oldAccount.Name} -> {_newAccount.Name}");
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            _accountService.UpdateAccount(_oldAccount);
            _executed = false;
            Console.WriteLine($"[COMMAND] Account edit undone: {_newAccount.Name} -> {_oldAccount.Name}");
        }
    }
}