using SD_SE_2.BaseCatalogue.IO.Export;
using SD_SE_2.Domain.InputOutput;

namespace SD_SE_2.BaseCatalogue.Entities;

public class BankAccount : Entity, IExportable
{
    public decimal Balance { get; internal set; }
    public bool IsActive { get; set; } = true;
        
    public BankAccount(string name, decimal initialBalance = 0)
    {
        Name = name;
        Balance = initialBalance;
    }

    public BankAccount()
    { }

    public void UpdateBalance(decimal balanceChange)
    {
        Balance += balanceChange;
    }

    public void AcceptExporter(Exporter exporter)
    {
        exporter.Export(this);
    }
}