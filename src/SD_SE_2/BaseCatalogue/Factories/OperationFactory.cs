using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.Factories;

public class OperationFactory(IAccountRepository accountRepository, ICategoryRepository categoryRepository)
    : IOperationFactory
{
    public Operation CreateOperation(OperationType type, Guid accountId, decimal amount, Guid categoryId,
        string description)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        if (description == null)
        {
            throw new ArgumentNullException(nameof(description));
        }

        if (!accountRepository.Exists(accountId))
        {
            throw new ArgumentException($"Account with id {accountId} does not exist");
        }

        if (!categoryRepository.Exists(categoryId))
        {
            throw new ArgumentException($"Category with id {categoryId} does not exist");
        }
        var operation = new Operation(type, accountId, amount, categoryId, description);
        return operation;
    }
}