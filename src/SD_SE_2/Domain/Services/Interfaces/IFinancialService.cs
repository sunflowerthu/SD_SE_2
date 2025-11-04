using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Services;

public interface IFinancialService
{
    void AddOperation(Operation operation);
    void UpdateOperation(Operation operation);
    void DeleteOperation(Guid operationId);
    decimal RecalculateBalance(Guid accountId);
}