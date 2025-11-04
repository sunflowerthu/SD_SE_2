using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Observers.Interfaces;

public interface IOperationObserver
{
    void OnOperationAdded(Operation operation);
    void OnOperationUpdated(Operation oldOperation, Operation newOperation);
    void OnOperationDeleted(Operation operation);
    void OnBalanceRecalculated(Guid accountId, decimal newBalance);
}