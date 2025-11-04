using SD_SE_2.Domain.Enums;

namespace SD_SE_2.Domain.Entities;

public class Operation : Entity
{
    public OperationType Type { get; }
    public Guid AccountId { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Description { get; } = string.Empty;
    public int CategoryId { get; private set; }

    public Operation(Guid operationId, OperationType type,
        Guid accountId, decimal amount, int categoryId, string description = null)
    {
        Amount = amount;
        Description = description;
        AccountId = accountId;
        CategoryId = categoryId;
        Type = type;
        Date = DateTime.Now;
        Name = $"Operation_{Id.ToString().Substring(0, 8)}";
    }
        
    public Operation() { }
}