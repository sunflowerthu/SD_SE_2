using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Services.Interfaces;

public interface IOperationService
{
    void AddOperation(Operation operation);
    void UpdateOperation(Operation operation);
    void DeleteOperation(Operation operation);
    Operation GetOperationById(Guid operationId);
}