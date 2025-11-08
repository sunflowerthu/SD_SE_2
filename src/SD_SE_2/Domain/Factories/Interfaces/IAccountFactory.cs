using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Factories;

public interface IAccountFactory
{
    BankAccount CreateAccount(string name, decimal initialBalance);
}