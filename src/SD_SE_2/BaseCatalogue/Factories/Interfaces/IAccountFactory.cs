using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.Factories.Interfaces;

public interface IAccountFactory
{
    BankAccount CreateAccount(string name, decimal initialBalance);
}