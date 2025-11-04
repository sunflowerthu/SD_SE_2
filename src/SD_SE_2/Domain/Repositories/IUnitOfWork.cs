using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Repositories;

public interface IUnitOfWork
{
    IRepository<BankAccount> BankAccounts { get; }
    IRepository<Category> Categories { get; }
    IRepository<Operation> Operations { get; }
    void Save();
}