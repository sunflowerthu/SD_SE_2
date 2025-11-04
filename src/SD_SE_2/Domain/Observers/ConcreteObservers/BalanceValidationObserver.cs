using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Observers.Interfaces;

namespace SD_SE_2.Domain.Observers.ConcreteObservers;

public class BalanceValidationObserver : IOperationObserver
{
    public void OnOperationAdded(Operation operation)
    {
        if (operation.Amount > 100000)
        {
            Console.WriteLine($"[VALIDATION] Large operation detected: {operation.Amount:C}");
        }
    }

    public void OnOperationUpdated(Operation oldOperation, Operation newOperation) { }
    public void OnOperationDeleted(Operation operation) { }
    public void OnBalanceRecalculated(Guid accountId, decimal newBalance) { }
}