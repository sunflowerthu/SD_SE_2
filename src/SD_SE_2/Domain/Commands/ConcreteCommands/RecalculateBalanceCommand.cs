using SD_SE_2.Domain.Repositories;
using SD_SE_2.Domain.Services;

namespace SD_SE_2.Domain.Commands;

public class RecalculateBalanceCommand : ICommand
{
    private readonly Guid _accountId;
    private readonly IFinancialService _financialService;
    private readonly BankAccountRepository _accountRepository;
    private decimal _previousBalance;
    private bool _executed = false;

    public string Description => $"Recalculate balance for account: {_accountId}";

    public RecalculateBalanceCommand(Guid accountId, IFinancialService financialService, BankAccountRepository accountRepository)
    {
        _accountId = accountId;
        _financialService = financialService;
        _accountRepository = accountRepository;
    }

    public void Execute()
    {
        if (!_executed)
        {
            var account = _accountRepository.GetById(_accountId);
            _previousBalance = account?.Balance ?? 0;
            
            _financialService.RecalculateBalance(_accountId);
            _executed = true;
        }
    }

    public void Undo()
    {
        if (_executed)
        {
            var account = _accountRepository.GetById(_accountId);
            if (account != null)
            {
                account.Balance = _previousBalance;
                _accountRepository.Update(account);
                Console.WriteLine($"Balance restored to previous value: {_previousBalance:C}");
            }
            _executed = false;
        }
    }
}