using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Factories;

public interface IOperationFactory
{
    Operation CreateOperation(OperationType type,
        Guid accountId, decimal amount, Guid categoryId, string description);
}