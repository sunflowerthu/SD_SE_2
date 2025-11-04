using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Observers.Interfaces;

namespace SD_SE_2.Domain.Observers.ConcreteObservers;

public class BalanceValidationObserver : IOperationObserver
{
    public void OnOperationAdded(Operation operation)
    {
        if (operation.Amount <= 0)
        {
            Console.WriteLine($"[VALIDATION ERROR] Invalid amount: {operation.Amount} - {operation.Description}");
        }
    }

    public void OnOperationUpdated(Operation oldOperation, Operation newOperation) { }
    public void OnOperationDeleted(Operation operation) { }
    public void OnBalanceRecalculated(Guid accountId, decimal newBalance) { }
}