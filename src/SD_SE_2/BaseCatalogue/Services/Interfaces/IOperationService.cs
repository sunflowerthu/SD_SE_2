using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Services.Interfaces;

public interface IOperationService
{
    void AddOperation(Operation operation);
    void UpdateOperation(Operation operation);
    void DeleteOperation(Operation operation);
    Operation GetOperationById(Guid operationId);
    IEnumerable<Operation> GetAllOperations();
}