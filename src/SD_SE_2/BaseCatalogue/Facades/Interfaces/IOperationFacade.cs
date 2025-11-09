using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Facades;

public interface IOperationFacade
{
    public void CreateOperation(OperationType type, Guid accountId, decimal amount, Guid categoryId,
        string description);

    void EditOperation(Guid operationId, OperationType newType, decimal newAmount, Guid newCategoryId, string? newDescription);
    void DeleteOperation(Guid operationId);
    IEnumerable<Operation> GetAllOperations();
}