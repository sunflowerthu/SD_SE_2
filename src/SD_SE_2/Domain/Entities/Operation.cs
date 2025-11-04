using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Entities;

public class Operation : Entity
{
    public OperationType Type { get; }
    public Guid AccountId { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Description { get; }
    public Guid CategoryId { get; private set; }

    public Operation(Guid operationId, OperationType type,
        Guid accountId, decimal amount, Guid categoryId, string description = "")
    {
        Amount = amount;
        Description = description;
        AccountId = accountId;
        CategoryId = categoryId;
        Type = type;
        Date = DateTime.Now;
        Name = $"Operation_{Id.ToString().Substring(0, 8)}";
    }
}