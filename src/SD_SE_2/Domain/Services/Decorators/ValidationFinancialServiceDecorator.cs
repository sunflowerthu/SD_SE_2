using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Services.Decorators;

public class ValidationFinancialServiceDecorator : IFinancialService
{
    private readonly IFinancialService _decorated;

    public ValidationFinancialServiceDecorator(IFinancialService decorated)
    {
        _decorated = decorated;
    }

    public void AddOperation(Operation operation)
    {
        ValidateOperation(operation);
        _decorated.AddOperation(operation);
    }

    public void UpdateOperation(Operation operation)
    {
        ValidateOperation(operation);
        _decorated.UpdateOperation(operation);
    }

    public void DeleteOperation(Guid operationId) => _decorated.DeleteOperation(operationId);
    public decimal RecalculateBalance(Guid accountId) => _decorated.RecalculateBalance(accountId);

    private void ValidateOperation(Operation operation)
    {
        if (operation.Amount <= 0)
            throw new ArgumentException("Amount must be positive");

        if (string.IsNullOrWhiteSpace(operation.Description))
            throw new ArgumentException("Description is required");

        if (operation.Date > DateTime.Now)
            throw new ArgumentException("Operation date cannot be in the future");
    }
}