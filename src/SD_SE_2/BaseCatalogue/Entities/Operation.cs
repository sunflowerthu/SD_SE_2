using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.IO.Export;

namespace SD_SE_2.BaseCatalogue.Entities;

public class Operation : Entity, IExportable
{
    public OperationType Type { get; init; }
    public Guid AccountId { get; init; }
    public decimal Amount { get; init; }
    public DateTime Date { get; set; }
    public string Description { get; init; }
    public Guid CategoryId { get; set; }

    public Operation(OperationType type,
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

    public Operation()
    { }

    public void AcceptExporter(Exporter exporter)
    {
        exporter.Export(this);
    }
}