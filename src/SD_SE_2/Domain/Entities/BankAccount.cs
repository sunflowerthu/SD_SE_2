namespace SD_SE_2.Domain.Entities;

public class BankAccount : Entity
{
    public decimal Balance { get; private set; }
    public string Currency { get; set; } = "RUB";
    public bool IsActive { get; set; } = true;

    public BankAccount() { }
        
    public BankAccount(string name, decimal initialBalance = 0)
    {
        Name = name;
        Balance = initialBalance;
    }
}