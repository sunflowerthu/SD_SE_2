using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Factories.Interfaces;

namespace SD_SE_2.BaseCatalogue.Factories;

public class AccountFactory : IAccountFactory
{
    public BankAccount CreateAccount(string name, decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentException("Initial balance cannot be negative");
        }
        var account = new BankAccount(name, initialBalance);
        return account;
    }
}