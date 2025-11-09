using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;

namespace SD_SE_2.BaseCatalogue.Facades.Interfaces;

public interface IOperationFacade
{
    public void CreateOperation(OperationType type, Guid accountId, decimal amount, Guid categoryId,
        string description);

    void EditOperation(Guid operationId, OperationType newType, decimal newAmount, Guid newCategoryId, string? newDescription);
    void DeleteOperation(Guid operationId);
    IEnumerable<Operation> GetAllOperations();
}