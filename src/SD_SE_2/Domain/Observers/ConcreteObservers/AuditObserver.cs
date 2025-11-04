using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Observers.Interfaces;

namespace SD_SE_2.Domain.Observers.ConcreteObservers;

public class AuditObserver : IOperationObserver
{
    private readonly List<string> _auditLog = new();

    public void OnOperationAdded(Operation operation)
    {
        var message = $"[AUDIT] ADD: {operation.Description} | {operation.Amount:C}";
        _auditLog.Add(message);
    }

    public void OnOperationUpdated(Operation oldOperation, Operation newOperation)
    {
        var message = $"[AUDIT] UPDATE: {oldOperation.Description} -> {newOperation.Description}";
        _auditLog.Add(message);
    }

    public void OnOperationDeleted(Operation operation)
    {
        var message = $"[AUDIT] DELETE: {operation.Description}";
        _auditLog.Add(message);
    }

    public void OnBalanceRecalculated(Guid accountId, decimal newBalance)
    {
        var message = $"[AUDIT] BALANCE_RECALC: Account {accountId} -> {newBalance:C}";
        _auditLog.Add(message);
    }
}