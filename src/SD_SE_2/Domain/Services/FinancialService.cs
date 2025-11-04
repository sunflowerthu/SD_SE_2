using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Services;

public class FinancialService : IFinancialService
{
    private readonly OperationRepository _operationRepository;
    private readonly BankAccountRepository _accountRepository;

    public FinancialService(OperationRepository operationRepository, 
                          BankAccountRepository accountRepository)
    {
        _operationRepository = operationRepository;
        _accountRepository = accountRepository;
    }

    public void AddOperation(Operation operation)
    {
        _operationRepository.Add(operation);
        UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
    }

    public void UpdateOperation(Operation operation)
    {
        var oldOperation = _operationRepository.GetById(operation.Id);
        if (oldOperation != null)
        {
            UpdateAccountBalance(oldOperation.AccountId, -oldOperation.Amount, oldOperation.Type);
            
            _operationRepository.Update(operation);
            
            UpdateAccountBalance(operation.AccountId, operation.Amount, operation.Type);
        }
    }

    public void DeleteOperation(Guid operationId)
    {
        var operation = _operationRepository.GetById(operationId);
        if (operation != null)
        {
            UpdateAccountBalance(operation.AccountId, -operation.Amount, operation.Type);
            _operationRepository.Delete(operationId);
        }
    }

    private void UpdateAccountBalance(Guid accountId, decimal amount, OperationType type)
    {
        var account = _accountRepository.GetById(accountId);
        if (account != null)
        {
            var balanceChange = type == OperationType.Income ? amount : -amount;
            account.UpdateBalance(balanceChange);
            _accountRepository.Update(account);
            
            Console.WriteLine($"Account {account.Name} balance updated: {balanceChange:+0.00;-0.00;0} -> {account.Balance:C}");
        }
    }

    public decimal RecalculateBalance(Guid accountId)
    {
        var account = _accountRepository.GetById(accountId);
        if (account == null)
        {
            Console.WriteLine($"Account with ID {accountId} not found");
            return 0;
        }

        var operations = _operationRepository.GetByAccountId(accountId);
        var newBalance = operations.Sum(o => o.Type == OperationType.Income ? o.Amount : -o.Amount);
        
        account.Balance = newBalance;
        _accountRepository.Update(account);
        
        Console.WriteLine($"Balance recalculated for {account.Name}: {newBalance:C}");
        return newBalance;
    }

    public void RecalculateAllBalances()
    {
        var accounts = _accountRepository.GetAll();
        Console.WriteLine($"Recalculating balances for {accounts.Count()} accounts...");
        
        foreach (var account in accounts)
        {
            RecalculateBalance(account.Id);
        }
        
        Console.WriteLine("All balances recalculated");
    }

    public (decimal Income, decimal Expense, decimal Balance) GetPeriodSummary(DateTime startDate, DateTime endDate)
    {
        var income = _operationRepository.GetTotalIncome(startDate, endDate);
        var expense = _operationRepository.GetTotalExpense(startDate, endDate);
        var balance = income - expense;

        return (income, expense, balance);
    }

    public Dictionary<string, decimal> GetCategorySummary(DateTime startDate, DateTime endDate, CategoryRepository categoryRepo)
    {
        var categoryTotals = _operationRepository.GetCategoryTotals(startDate, endDate);
        var categories = categoryRepo.GetAll();
        
        return categoryTotals.ToDictionary(
            kvp => categories.First(c => c.Id == kvp.Key).Name,
            kvp => kvp.Value
        );
    }
}