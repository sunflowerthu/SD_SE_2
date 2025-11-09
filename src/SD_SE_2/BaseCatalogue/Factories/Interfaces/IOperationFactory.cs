using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;

namespace SD_SE_2.BaseCatalogue.Factories.Interfaces;

public interface IOperationFactory
{
    Operation CreateOperation(OperationType type,
        Guid accountId, decimal amount, Guid categoryId, string description);
}