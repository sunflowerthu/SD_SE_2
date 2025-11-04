using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Observers.Interfaces;

namespace SD_SE_2.Domain.Observers.ConcreteObservers;

public class ReportingObserver : IOperationObserver
{
    private readonly Dictionary<OperationType, int> _operationCounts = new();
    private readonly Dictionary<Guid, decimal> _accountActivity = new();
    private int _totalOperations = 0;

    public ReportingObserver()
    {
        _operationCounts[OperationType.Income] = 0;
        _operationCounts[OperationType.Expense] = 0;
    }

    public void OnOperationAdded(Operation operation)
    {
        _totalOperations++;
        _operationCounts[operation.Type]++;
        
        if (!_accountActivity.ContainsKey(operation.AccountId))
            _accountActivity[operation.AccountId] = 0;
        
        _accountActivity[operation.AccountId] += operation.Amount;
    }

    public void OnOperationUpdated(Operation oldOperation, Operation newOperation)
    {
        // Обновляем статистику при изменении операций
        _operationCounts[oldOperation.Type]--;
        _operationCounts[newOperation.Type]++;
        
        _accountActivity[oldOperation.AccountId] -= oldOperation.Amount;
        _accountActivity[newOperation.AccountId] += newOperation.Amount;
    }

    public void OnOperationDeleted(Operation operation)
    {
        _totalOperations--;
        _operationCounts[operation.Type]--;
        _accountActivity[operation.AccountId] -= operation.Amount;
    }

    public void OnBalanceRecalculated(Guid accountId, decimal newBalance) { }

    public void PrintStatistics()
    {
        Console.WriteLine("\n=== OPERATIONS STATISTICS ===");
        Console.WriteLine($"Total operations: {_totalOperations}");
        Console.WriteLine($"Income operations: {_operationCounts[OperationType.Income]}");
        Console.WriteLine($"Expense operations: {_operationCounts[OperationType.Expense]}");
        Console.WriteLine($"Active accounts: {_accountActivity.Count}");
        
        foreach (var account in _accountActivity)
        {
            Console.WriteLine($"Account {account.Key}: {account.Value:C} total activity");
        }
    }
}